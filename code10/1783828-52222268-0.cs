    public void Watch()
    {
          FileSystemWatcher watcher = new FileSystemWatcher();
          watcher.Path = "directorypath\\";
          watcher.NotifyFilter = NotifyFilters.LastWrite;
          watcher.Created += new FileSystemEventHandler(OnChanged);
          watcher.EnableRaisingEvents = true;
    }
