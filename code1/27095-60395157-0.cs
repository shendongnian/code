            String CurrentUser = Environment.UserName;
            Process[] allExcelProcesses = Process.GetProcessesByName("excel");
            if (null != allExcelProcesses)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C TASKKILL /F /FI \"USERNAME eq " + CurrentUser + "\" /IM EXCEL.EXE";
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }
