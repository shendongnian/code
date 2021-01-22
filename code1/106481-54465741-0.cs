    private FileSystemWatcher watcher = new FileSystemWatcher();
    ...
    watcher.Path = "E:\\data";
    watcher.NotifyFilter = NotifyFilters.LastWrite ;
    watcher.Filter = "data.txt";
    watcher.Changed += new FileSystemEventHandler(OnChanged);
    watcher.EnableRaisingEvents = true;
    ...
    private void OnChanged(object source, FileSystemEventArgs e)
       {
        System.Timers.Timer t = new System.Timers.Timer();
        try
        {
            watcher.Changed -= new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = false;
            
            t.Interval = 500;
            t.Elapsed += (sender, args) => t_Elapsed(sender, e);
            t.Start();
        }
        catch(Exception ex) {
            ;
        }
    }
    private void t_Elapsed(object sender, FileSystemEventArgs e) 
       {
        ((System.Timers.Timer)sender).Stop();
           //.. Do you stuff HERE ..
         watcher.Changed += new FileSystemEventHandler(OnChanged);
         watcher.EnableRaisingEvents = true;
    }
