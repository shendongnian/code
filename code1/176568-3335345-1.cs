    public static class FileSystemWatcherExtensions
    {
        public static Dictionary<string, string> MyProperty {get;set;}
        public static string GetMyProperty(this FileSystemWatcher watcher)
        {
            if (MyProperty != null && MyProperty.ContainsKey[watcher.GetHashCode()]) {
                return FileSystemWatcherExtensions.MyProperty[watcher.GetHashCode()];
            } else {
                return null;
            }
        }
        public static void SetMyProperty(this FileSystemWatcher watcher, string value)
        {
            if (MyProperty == null) {
                MyProperty = new Dictionary<string, string>();
            }
            FileSystemWatcherExtensions.MyProperty[watcher.GetHashCode()] = value;
        }
    }
    // I changed this example to allow for instance methods - but the naming can be
    // improved...
