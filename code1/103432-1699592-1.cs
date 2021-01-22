     private void CreatorLoop(object state) 
     {
       if (Monitor.TryEnter(lockObject))
       {
         try
         {
           // Work here
         }
         finally
         {
           Monitor.Exit(lockObject);
         }
       }
     }
