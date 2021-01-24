     class program
        {
            static void Main()
            {
                var watcher = new Watcher();
                watcher.Start();
    
                // hook into the event
                watcher.ChangedEvent += WatcherChanged;
    
                Console.Read();
            }
    
            private static void WatcherChanged(object sender, string e)
            {
                Console.WriteLine($"clean path is {e}");
            }
        }
    
        class Watcher
        {
            public EventHandler<string> ChangedEvent;
    
            public void Start()
            {
                DriveInfo[] alldrives = DriveInfo.GetDrives();
                // etc.
            }
    
            private void onchanged(object sender, FileSystemEventArgs e)
            {
                int index1 = e.FullPath.IndexOf(e.Name);
                string cleanpath = e.FullPath.Remove(index1, (e.FullPath.Length) - (index1));
    
                // fire the event
                if (this.ChangedEvent != null)
                {
                    this.ChangedEvent(this, cleanpath);
                }
            }
