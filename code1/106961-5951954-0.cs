    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Linq;
    using System.Security.Permissions;
    using System.Diagnostics;
    using System.IO;
    namespace MyApp
    {
        [RunInstaller(true)]
        public partial class ScheduleTask : System.Configuration.Install.Installer
        {
            public ScheduleTask()
            {
                InitializeComponent();
            }
            [SecurityPermission(SecurityAction.Demand)]
            public override void Commit(IDictionary savedState)
            {
                base.Commit(savedState);
                RemoveScheduledTask();
                string installationPath = Context.Parameters["DIR"] ?? "";
                //Without the replace, results in c:\path\\MyApp.exe
                string executablePath = Path.Combine(installationPath, "MyApp.exe").Replace("\\\\", "\\");
                Process scheduler = Process.Start("schtasks.exe",string.Format("/Create /RU SYSTEM /SC HOURLY /MO 2 /TN \"MyApp\" /TR \"\\\"{0} /sched\\\"\" /st 00:00", executablePath));
                scheduler.WaitForExit();
            }
            [SecurityPermission(SecurityAction.Demand)]
            public override void Uninstall(IDictionary savedState)
            {
                base.Uninstall(savedState);
                RemoveScheduledTask();
            }
            private void RemoveScheduledTask() {
                Process scheduler = Process.Start("schtasks.exe", "/Delete /TN \"MyApp\" /F");
                scheduler.WaitForExit();
            }
        }
    }
