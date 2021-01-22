    // Consider having a List<String> named _changedFiles
    private void OnChanged(object source, FileSystemEventArgs e)
    {
        lock (_changedFiles)
        {
            if (_changedFiles.Contains(e.FullPath))
            {
                return;
            }
        }
        // do your stuff
        System.Timers.Timer timer = new Timer(1000) { AutoReset = false };
        timer.Elapsed += (timerElapsedSender, timerElapsedArgs) =>
        {
            lock (_changedFiles)
            {
                _changedFiles.Remove(e.FullPath);
            }
        };
       timer.Start();
    }
