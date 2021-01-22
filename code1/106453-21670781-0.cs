    var watcher = new FileSystemWatcher("./");
    
    Observable.FromEventPattern<FileSystemEventArgs>(watcher, "Changed")
                .Throttle(new TimeSpan(50000000))
                .Subscribe(HandleChangeEvent);
                
    watcher.EnableRaisingEvents = true;
