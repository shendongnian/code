                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "hostname",
                        Arguments = "-I",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    Console.WriteLine( proc.StandardOutput.ReadLine());
                    // do something with line
                }
