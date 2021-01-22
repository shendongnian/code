    public Dispose()
    {
        try
        {
            Dispose(true); //true: safe to free managed resources
        }
        finally
        {
            base.Dispose();
        }
    }
