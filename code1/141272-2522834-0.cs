    IDisposable x = GetObject("invalid name");
    try
    {
        if (x != null) 
        {
            // etc...
        }
    }
    finally
    {
        if(x != null)
        {
            x.Dispose();
        }
    }
