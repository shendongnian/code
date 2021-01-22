    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Management;
    using System.Management.Instrumentation;
    
    namespace WMI
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            WMITest.MyWMIInterface pIntf_m;
    
            private void btnPublish_Click(object sender, EventArgs e)
            {
                try
                {
                    pIntf_m = WMITest.InstrumentationProvider.Publish();
                }
                catch (ManagementException exManagement)
                {
                    MessageBox.Show(exManagement.ToString());
                }
                catch (Exception exPublish)
                {
                    MessageBox.Show(exPublish.ToString());
                }
            }
        }
    }
