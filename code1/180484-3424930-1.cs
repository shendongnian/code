    // Just in case someone wants to inherit your class and lock it as well ...
    private static object _padlock = new object();
    try
    {
      serviceTimer.Stop(); 
    
      lock (_padlock)
        { 
            // do some heavy processing... 
        } 
    }
    finally
    {
      serviceTimer.Start(); 
    }
