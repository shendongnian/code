    Process[] processes = Process.GetProcesses();
                foreach (Process pr in processes)
                {
                    try
                    {
                        Console.WriteLine("App Name: {0}, Process Name: {1}", Path.GetFileName(pr.MainModule.FileName), pr.ProcessName);
                    }
                    catch { }
                }
