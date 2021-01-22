    public class MyFileSystemWatcherManager
    {
        public string XmlConfigPath { get; set; }
        public FileSystemWatcher Watcher { get; set; }
        public MyFileSystemWatcherManager()
        {
            Watcher = new FileSystemWatcher();
        }
    }
