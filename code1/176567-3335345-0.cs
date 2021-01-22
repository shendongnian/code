    public static class FileSystemWatcherExtensions
    {
        public static string MyProperty {get;set;}
        public static string GetMyProperty(this FileSystemWatcher watcher)
        {
            return FileSystemWatcherExtensions.MyProperty;
        }
        public static void SetMyProperty(this FileSystemWatcher watcher, string value)
        {
            FileSystemWatcherExtensions.MyProperty = value;
        }
    }
