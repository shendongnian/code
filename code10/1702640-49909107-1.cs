    private void CreateWatcher()
    {
        var watcher = new FileSystemWatcher();
        watcher.Filter = "TestFile.pdf";
        watcher.NotifyFilter = NotifyFilters.FileName;
        watcher.Created += new FileSystemEventHandler(OnWatcherFileCreated);
        watcher.IncludeSubdirectories = true;
        watcher.Path = "C:\\";
        watcher.EnableRaisingEvents = true;
    }
    private void OnWatcherFileCreated(object sender, FileSystemEventArgs e)
    {
        // Note: this happens in a separate non-UI thread.
        Console.WriteLine("Dropped onto: " + e.FullPath);
    }
