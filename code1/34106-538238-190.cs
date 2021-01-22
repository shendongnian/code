    public void Dispose()
    {
       Dispose(true); //I am calling you from Dispose, it's safe
       GC.SuppressFinalize(this); //Hey, GC: don't bother calling finalize later
    }
