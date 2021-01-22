                Process[] processes = Process.GetProcesses();
                foreach (var item in processes)
                {
                    if(item.MainWindowTitle.Length > 0)
                        Console.WriteLine(item.MainWindowTitle);
                }
