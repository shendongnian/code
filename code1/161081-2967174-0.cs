    public static void Foo()
    {
        // Create a new FileSystemWatcher and set its properties.
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = @"Your path";
        /* Watch for changes in LastAccess time */
        watcher.NotifyFilter = NotifyFilters.LastAccess;
        // Only watch text files.
        watcher.Filter = "*.txt";
        // Add event handlers.
        watcher.Changed += new FileSystemEventHandler(OnChanged);
        // Begin watching.
        watcher.EnableRaisingEvents = true;
    }
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        // Specify what is done when a file is changed, created, or deleted.
       Console.WriteLine("File: " +  e.FullPath + " " + e.ChangeType);
    }
