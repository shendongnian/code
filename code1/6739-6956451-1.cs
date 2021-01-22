    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    // Remember to add a reference to the System.Management assembly
    using System.Management;
    using System.Diagnostics;
    namespace ShutDown
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void btnShutDown_Click(object sender, EventArgs e)
            {
                ManagementBaseObject mboShutdown = null;
                ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
                mcWin32.Get();
                // You can't shutdown without security privileges
                mcWin32.Scope.Options.EnablePrivileges = true;
                ManagementBaseObject mboShutdownParams = mcWin32.GetMethodParameters("Win32Shutdown");
                // Flag 1 means we want to shut down the system
                mboShutdownParams["Flags"] = "1";
                mboShutdownParams["Reserved"] = "0";
                foreach (ManagementObject manObj in mcWin32.GetInstances())
                {
                    mboShutdown = manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
                }
            }
        }
    }
