    System.Threading.Timer DeleteFileTimer = null;
    private void CreateStartTimer()
    {
        TimeSpan InitialInterval = new TimeSpan(0,0,5);
        TimeSpan RegularInterval = new TimeSpan(5,0,0);
        DeleteFileTimer = new System.Threading.Timer(QueryDeleteFiles, null, 
                InitialInterval, RegularInterval);
    }
    private void QueryDeleteFiles(object state)
    {
        //Delete Files Here... (Fires Every Five Hours).
        //Warning: Don't update any UI elements from here without Invoke()ing
        System.Diagnostics.Debug.WriteLine("Deleting Files...");
    }
    private void StopDestroyTimer()
    {
        DeleteFileTimer.Change(System.Threading.Timeout.Infinite,
        System.Threading.Timeout.Infinite);
        DeleteFileTimer.Dispose();
    }
