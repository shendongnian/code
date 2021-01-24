    using System.Diagnostic.Stopwatch;
    ...
    private StopWatch Watcher = new StopWatch();
    ...
    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        Watcher.Start();
    }
    
    private void ObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        Watcher.Stop();
        long millis = Watcher.ElapsedMilliseconds;
        Watcher.Reset();
        File.AppendAllText("PATH/Timer.txt", millis.ToString());
    }
