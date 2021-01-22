       // try enter will return false if another thread owns the lock
       if (Monitor.TryEnter(lockObj))
       {
          try
          {
             // check last write time here, return if too soon; otherwise, write
          }
          finally
          {
             Monitor.Exit(lockobj);
          }
       }
