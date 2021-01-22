    _watcher = new FileSystemWatcher(path);
    _watcher.Created += (obj, e) =>
      Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
      {
        // Code to handle Created event
      };
    _watcher.Changed += (obj, e) =>
      Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
      {
        // Code to handle Changed event
      };
    _watcher.Renamed += (obj, e) =>
      Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
      {
        // Code to handle Renamed event
      };
    _watcher.Deleted += (obj, e) =>
      Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
      {
        // Code to handle Deleted event
      };
    // ...
    _watcher.EnableRaisingEvents = true;
