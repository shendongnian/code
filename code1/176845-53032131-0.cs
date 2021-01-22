        using System.Management;
        using System.Diagnostics;
        ...
        // Called when the Main Window is closed
        protected override void OnClosed(EventArgs EventArgs)
        {
            string query = "Select * From Win32_Process Where ParentProcessId = " + Process.GetCurrentProcess().Id;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();
            foreach (var obj in processList)
            {
                object data = obj.Properties["processid"].Value;
                if (data != null)
                {
                    // retrieve the process
                    var childId = Convert.ToInt32(data);
                    var childProcess = Process.GetProcessById(childId);
                    // ensure the current process is still live
                    if (childProcess != null) childProcess.Kill();
                }
            }
            Environment.Exit(0);
        }
