            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    Assembly test = Assembly.LoadFrom(process.MainModule.FileName);
                    Console.WriteLine(test.FullName);
                    foreach (Type type in test.GetTypes())
                        Console.WriteLine(type.FullName);
                }
                catch
                {
                    continue;
                }
            }
