    private static object eventSyncLock = new object();
    
    protected virtual void OnProgressChanged(ProgressChangedEventArgs e)
    {
        ProgressChangedEventHandler handler;
        lock(eventSyncLock)
        {
          handler = ProgressChanged;
        }
        if (handler != null)
            handler(this, e);
    }
