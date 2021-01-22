    using (var watcher = new FileSystemWatcher(MatlabPath, fileName))
    {
        var wait = new EventWaitHandle(false, EventResetMode.AutoReset);
        watcher.EnableRaisingEvents = true;
        watcher.Changed += delegate(object sender, FileSystemEventArgs e)
        {
           wait.Set();
        };
        if (!wait.WaitOne(MillissecondsTimeout))
        {
            throw new TimeoutException();
        }
     }
