    var fsw = new FileSystemWatcher("C:\\");
    fsw.NotifyFilter = NotifyFilters.LastAccess;
    fsw.Changed += OnFileAccessed
    
    private static void OnFileAccessed( object sender, FileSystemEventArgs e )
    {
    	...
    }
