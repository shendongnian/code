    var switchThread =
      (FileSystemEventHandler handler) =>
        (object obj, FileSystemEventArgs e) =>
          Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
           handler(obj, e))
    _watcher = new FileSystemWatcher(path);
    _watcher.Created += switchThread(OnCreated);
    _watcher.Changed += switchThread(OnChanged);
    _watcher.Deleted += switchThread(OnDeleted);
    _watcher.Renamed += switchThread(OnRenamed);
    _watcher.EnableRaisingEvents = true;
