            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "netsh.exe",
                    Arguments = "lan reconnect",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    Verb = "runas"
                }
            };
            proc.Start();
            string line = proc.StandardOutput.ReadToEnd();
            MessageBox.Show(line);
