    public void Dispose() 
    {
        Dispose(true);
        // Use SupressFinalize in case a subclass
        // of this type implements a finalizer.
        GC.SuppressFinalize(this);      
    }
