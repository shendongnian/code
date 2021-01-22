    ~MyClass()
    {
        Dispose(false);
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected void Dispose(disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                // Dispose managed resources here.
            }
            // Dispose unmanaged resources here.
        }
        this.disposed = true;
    }
