        bool let = false;
        FileSystemWatcher watcher;
        string path = "C:/Users/jamie/OneDrive/Pictures/Screenshots";
        public WatchPlotDirectory()
        {
            watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;
        }
        void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (let==false) {
                string mgs = string.Format("File {0} | {1}",
                                           e.FullPath, e.ChangeType);
                Console.WriteLine("onchange: " + mgs);
                let = true;
            }
            else
            {
                let = false;
            }
           
            
        }
        void OnRenamed(object sender, RenamedEventArgs e)
        {
            string log = string.Format("{0} | Renamed from {1}",
                                       e.FullPath, e.OldName);
            Console.WriteLine("onrenamed: " + log);
        }
        public void setPath(string path)
        {
            this.path = path;
        }
    }
