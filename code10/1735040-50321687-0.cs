    public class FileMon
    {
        public static void Run()
        {
            FileSystemWatcher fsWatcher = new FileSystemWatcher();
            fsWatcher.Path = @"C:\Test\";        
            fsWatcher.Filter = "*.*" ;
            fsWatcher.IncludeSubdirectories = true;
            // Monitor all changes specified in the NotifyFilters.
            fsWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName ;
            fsWatcher.EnableRaisingEvents = true;
            // Raise Event handlers.
            fsWatcher.Changed += OnChanged;
            fsWatcher.Created += OnCreated;
            Console.WriteLine("[Enter] to end"); Console.ReadLine();
            fsWatcher.EnableRaisingEvents = false;
        }
        static void Worker(object state)
        {
            FileSystemEventArgs fsArgs = state as FileSystemEventArgs;
            bool done = false;
            FileInfo fi = new FileInfo(fsArgs.FullPath);
            
            do
            {
                try
                {
                    using (File.Open(fsArgs.FullPath, FileMode.Open))
                    {
                        done = true;
                    }
                }
                catch
                {
                    done = false;
                }
                Thread.Sleep(1000);
            } while (!done);
            Console.WriteLine("DOne");
            string dateStamp = DateTime.Now.ToString("fff");
            string fName = fi.FullName;
            string newFile = fsArgs.FullPath + dateStamp;
            File.Move(fsArgs.FullPath, newFile);
        }
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Created {e.ChangeType} : {e.Name}");
            ThreadPool.QueueUserWorkItem(Worker, e);
        }
        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.ChangeType} : {e.FullPath}");
        }
    }
