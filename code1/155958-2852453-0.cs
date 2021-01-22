    Monitor.Enter(_client);
    try
    {
      // do your stuff
    
    }
    finally {
      Monitor.Exit(_client);
    }
