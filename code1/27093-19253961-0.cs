    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Security.Principal;
    using System.Runtime.InteropServices;
    
    namespace KillRDPClip
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process[] processlist = Process.GetProcesses();
                foreach (Process theprocess in processlist)
                {
                    String ProcessUserSID = theprocess.StartInfo.EnvironmentVariables["USERNAME"];
                    String CurrentUser = Environment.UserName;
                    if (theprocess.ProcessName.ToLower().ToString() == "rdpclip" && ProcessUserSID == CurrentUser)
                    {
                        theprocess.Kill();
                    }
                }
            }
        }
    }
