            System.Diagnostics.Process p = new System.Diagnostics.Process
            {
                StartInfo =
                {
                    FileName = "netsh.exe",
                    Arguments = $"interface set interface \"{nicName}\" {command}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            bool started = p.Start();
