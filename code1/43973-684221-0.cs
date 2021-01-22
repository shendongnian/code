    if (Monitor.TryEnter(lockobj))
    {
      try
      {
        // we got the lock, do your work
      }
      finally
      {
         Monitor.Exit(lockobj);
      }
    }
    else
    {
      // another elapsed has the lock
    }
