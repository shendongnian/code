    class RemoteSystemTime 
        {
            static void Main(string[] args)
            {
                try
                {
                    string machineName = "vista-pc";
    
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.FileName = "net";
                    proc.StartInfo.Arguments = @"time \\" + machineName;
                    proc.Start();
                    proc.WaitForExit();
    
                    List<string> results = new List<string>();
                    while (!proc.StandardOutput.EndOfStream)
                    {
                        string currentline = proc.StandardOutput.ReadLine();
                        if (!string.IsNullOrEmpty(currentline))
                        {
                            results.Add(currentline);
                        }
                    }
    
                    string currentTime = string.Empty;
                    if (results.Count > 0 && results[0].ToLower().StartsWith(@"current time at \\" +                                               machineName.ToLower() + " is "))
                    {
                        currentTime = results[0].Substring((@"current time at \\" + machineName.ToLower() + " is                             ").Length);
    
                        Console.WriteLine(DateTime.Parse(currentTime));
                        Console.ReadLine();
                    }
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
