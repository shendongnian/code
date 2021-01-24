    object locker = new object();
    void ThreadMethod()
    {
      if(Monitor.TryEnter(locker, TimeSpan.FromMiliseconds(1))
      {
         try
         {
           //do the thread code
         }
         finally
         {
           Monitor.Exit(locker);
         }
      } else
        return; //means that the lock has not been aquired
    }
