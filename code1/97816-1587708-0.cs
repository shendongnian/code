    Exception unhandledException = null;
    try
    {
        ...
    }
    catch (Exception ex)
    {
        unhandledException = ex;
    }
    finally
    {
        CleanupAppDomain(mainApp);
    }
    
    if (unhandledException != null)
        UnhandledException(this, new UnhandledExceptionEventArgs(unhandledException, false));
