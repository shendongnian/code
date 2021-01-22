    public void Dispose()
    {
       Dispose(true); //i am calling you from Dispose, it's safe
       GC.SuppressFinalize(this); //GC don't bother calling finalize
    }
