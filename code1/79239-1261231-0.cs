    using (FileSystemWatcher watcher = new FileSystemWatcher(folder))
    {
        if(!File.Exists(docname))
            for (int i = 0; i < 3; i++)
                watcher.WaitForChanged(WatcherChangeTypes.Created, i * 1000);
    }
