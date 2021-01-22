    public void Dispose()
    {
        Dispose(true);
        System.GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                if ($MEMBER$ != null)
                {
                    $MEMBER$.Dispose();
                    $MEMBER$ = null;
                }
            }
    
            disposed = true;
        }
    }
    
    ~$CLASS$()
    {
        Dispose(false);
    }
    
    private bool disposed;
