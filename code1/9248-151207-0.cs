    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    /// <summary>
    /// Force the background thread to exit.
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            lock (this.locker)
            {
                this.stop = true;
            }
        }
    }
    
    ~BackgroundWorker()
    {
        Dispose(false);
    }
