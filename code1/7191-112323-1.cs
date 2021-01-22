    // Declares the FileSystemWatcher object
    FileSystemWatcher watcher = new FileSystemWatcher(); 
    // We have to specify the path which has to monitor
     watcher.Path = @"\\somefilepath";     
     
    // This property specifies which are the events to be monitored
     watcher.NotifyFilter = NotifyFilters.LastAccess |
       NotifyFilters.LastWrite | NotifyFilters.FileName | notifyFilters.DirectoryName; 
    watcher.Filter = "*.*"; // Only watch text files.
    
    // Add event handlers for specific change events...
    watcher.Changed += new FileSystemEventHandler(OnChanged);
    watcher.Created += new FileSystemEventHandler(OnChanged);
    watcher.Deleted += new FileSystemEventHandler(OnChanged);
    watcher.Renamed += new RenamedEventHandler(OnRenamed);
    // Begin watching.
    watcher.EnableRaisingEvents = true;
    
    
    // Define the event handlers.
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
    // Specify what is done when a file is changed, created, or deleted.
    }
    private static void OnRenamed(object source, RenamedEventArgs e)
    {
    // Specify what is done when a file is renamed.
    }
