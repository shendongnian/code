    while (true)
    {
       myqAddedSignal.WaitOne();
       lock (myLock)
       {
          // pull everything off myQ into a list
          // clear myQ
          myqAddedSignal.Reset();
       }
    
       foreach (obj in copyOfMyQ)
       {
          ...
       }
    }
