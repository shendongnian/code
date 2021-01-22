    Monitor.Enter(lockObject);
    
    try
    {
        // code within lock { }
    }
    finally
    {
        Monitor.Exit(lockObject);
    }
