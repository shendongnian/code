        List<String> output = new List<string>();
        private bool checkIfJavaIsInstalled()
        {
            bool ok = false;
            
            Process process = new Process();
            try
            {
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.Arguments = "/c \"" + "java -version " +  "\"";
                process.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
                {
                    if (e.Data != null)
                    {
                        output.Add((string) e.Data);
                    }
                });
                process.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
                {
                    if (e.Data != null)
                    {
                        output.Add((String) e.Data);
                    }
                });
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                ok = (process.ExitCode == 0);
            }
            catch { }
 
            return (ok);
        }
