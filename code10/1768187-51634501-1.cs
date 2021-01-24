    public void Dispose()
    {
         this.Dispose(true);
         GC.SuppressFinalize(this);
    }
    protected void Dispose(bool disposing)
    {
        if (disposing && !this.isDisposed)
        {   // cancel the task, and wait until task completed:
            this.Cancel();
            this.IsDisposed = true;                 
        }
    }
