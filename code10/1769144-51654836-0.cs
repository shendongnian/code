    private void MonitorDirectory(string path)
    {
        _watcher = new FileSystemWatcher();
        _watcher.Path = path;
        _watcher.NotifyFilter = NotifyFilters.LastWrite;
        _watcher.Changed += FileCreated;
        _watcher.EnableRaisingEvents = true;
    }
    private void FileCreated(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType == WatcherChangeTypes.Created) {
			// do some work
		}
    }
