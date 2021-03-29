using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace Axolotl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string webhook = textBox1.Text;
            string content = textBox2.Text;
            using (DcWebHook dcWeb = new DcWebHook())
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                foreach (ManagementObject managementObject in mos.Get())
                {
                    String OSName = managementObject["Caption"].ToString();
                    dcWeb.ProfilePicture = "https://i.redd.it/wy2oybmp5ma41.png";
                    dcWeb.UserName = " master has got you something ";
                    dcWeb.WebHook = (webhook);
                    dcWeb.SendMessage("```" + content + "```");
                }
            }
        }
    }
}
