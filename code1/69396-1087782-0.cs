    System.Threading.Interlocked.Increment(ref _reportsRunning);
    try 
    {
      ...
    }
    finally
    {
       System.Threading.Interlocked.Decrement(ref _reportsRunning);
    }
