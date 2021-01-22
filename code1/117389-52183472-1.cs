        public string getUUID()
        {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "CMD.exe";
                startInfo.Arguments = "/C wmic csproduct get UUID";
                process.StartInfo = startInfo;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                return output;
        }
