    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    ~MyClass()
    {
        Dispose(false);
    }
    
    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Dispose of disposable objects here
           
        }
        // Other unmanaged cleanup here which will be called by the finalizer
        if (comInstance != null)
        {
             comInstance.FreeStuff();
             comInstance = null;
        }
        // Call base dispose if inheriting from IDisposable class.
        base.Dispose(true);
    }
