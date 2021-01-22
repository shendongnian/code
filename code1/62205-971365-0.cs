    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Management;
    namespace About_box
    {
        public partial class About : Form
        {
            public About()
            {
                InitializeComponent();
                FormLoad();
            }
    
            public void FormLoad()
            {
                SystemInfo si;
                SystemInfo.GetSystemInfo(out si);
    
                txtboxApplication.Text = si.AppName;
                txtboxVersion.Text = si.AppVersion;
                txtBoxComputerName.Text = si.MachineName;
                txtBoxMemory.Text = Convert.ToString((si.TotalRam / 1073741824)
                    + " GigaBytes");
                txtBoxProcessor.Text = si.ProcessorName;
                txtBoxOperatingSystem.Text = si.OperatingSystem;
                txtBoxOSVersion.Text = si.OperatingSystemVersion;
                txtBoxManufacturer.Text = si.Manufacturer;
                txtBoxModel.Text = si.Model;
            }
    
    
        }
    }
