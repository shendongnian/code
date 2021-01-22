    PrivateLock.WaitOne(-1, false);
    while (true)
    {
        // fetch Sched, so the whole loop sees a single value
        int iSched = Scheduled--; // implementation should be Interlocked.Decrement()
        if (iSched <= 0)
        {
           if (iSched < 0)
           {
              // should never get here, throw exception?
           }
           PrivateLock.Reset();                
           if (OnThreadEnd != null)                
               OnThreadEnd(this, null);                
           InternalLock.Set();                
           break; // break out of while
        }
        if (OnThreadExecute != null)              
           OnThreadExecute(this, null);
    }
