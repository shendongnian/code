    try
    {
        // ...
    }
    catch(Exception ex)
    {
        if (!Debugger.IsAttached)
        {
            ExceptionHandler.Frob(ex);
        }
        else
        {
            throw;
        }
    }
