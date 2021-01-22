    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Dispose managed resources.
            }
    
            // There are no unmanaged resources to release, but
            // if we add them, they need to be released here.
        }
        disposed = true;
    
        // If it is available, make the call to the
        // base class's Dispose(Boolean) method
        base.Dispose(disposing);
    }
