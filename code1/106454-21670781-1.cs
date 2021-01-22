    var watcher = new FileSystemWatcher("./");
    
    Observable.FromEventPattern<FileSystemEventArgs>(watcher, "Changed")
                .Throttle(new TimeSpan(500000))
                .Subscribe(HandleChangeEvent);
                
    watcher.EnableRaisingEvents = true;
