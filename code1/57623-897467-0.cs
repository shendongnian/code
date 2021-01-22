            using (var w = new System.IO.FileSystemWatcher("c:\\"))
            {
                w.IncludeSubdirectories = true;
                w.NotifyFilter = NotifyFilters.LastAccess;
                w.Changed += (object sender, FileSystemEventArgs e) =>
                            {
                                Console.WriteLine("{0} {1} at {2}", Path.Combine(e.FullPath, e.Name), e.ChangeType, DateTime.Now);
                            };
                w.EnableRaisingEvents = true;   
                Console.WriteLine("Press Enter to exit");
                Console.Read();
            }
