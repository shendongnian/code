      static void runCmdCommad(string cmd)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/C {cmd}";
            process.StartInfo = startInfo;
            process.Start();
        }
       static void DisableInternet(bool enable)
        {
            string disableNet = "wmic path win32_networkadapter where PhysicalAdapter=True call disable";
            string enableNet = "wmic path win32_networkadapter where PhysicalAdapter=True call enable";
            runCmdCommad(enable ? enableNet :disableNet);
        }
