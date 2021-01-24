    public static string Bash(this string cmd)
            {
                string result = String.Empty;
    
                try
                {
                    var escapedArgs = cmd.Replace("\"", "\\\"");
    
                    using (Process process = new Process())
                    {
                        process.StartInfo = new ProcessStartInfo
                        {
                            FileName = "/bin/bash",
                            Arguments = $"-c \"{escapedArgs}\"",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true,
                        };
    
                        process.Start();
                        result = process.StandardOutput.ReadToEnd();
                        process.WaitForExit(1500);
                        process.Kill();
                    };
                }
                catch (Exception ex)
                {
                    //Logger.ErrorFormat(ex.Message, ex);
                }
                return result;
            }
