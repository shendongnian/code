    Monitor.Enter(Lock);    
    try
    {
        // Only one thread at a time is able to enter this section
    }
    finally
    {
        Monitor.Exit(Lock);
    }
