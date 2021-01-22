    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
    ~MyClass()
    {
        this.Dispose(false);
    }
    protected virtual void Dispose(bool disposing)
    {
        // if (disposing)
        // {
        //      // Managed
        // }
        if (comInstance != null)
        {
            comInstance.FreeStuff();
            comInstance = null;
        }
        // base.Dispose(disposing) if required
    }
