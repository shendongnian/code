    IDisposable x = GetObject("invalid name");
    try
    {
        // etc...
    }
    finally
    {
        if(x != null)
        {
            x.Dispose();
        }
    }
