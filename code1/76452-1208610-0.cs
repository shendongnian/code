    public void Run()
    {
        watcher.Path = @"C:\queue";
        watcher.Created += new FileSystemEventHandler(watcher_Created);
        watcher.EnableRaisingEvents = true;
        try
        {
            while(true)
                Thread.Sleep();
        }
        catch(ThreadAbortedException)
        {
            return;
        }
    }
