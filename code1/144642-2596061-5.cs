       if (System.Threading.Monitor.TryEnter(_samplingLock))
       {
         try
         {
             .... // sample stuff
         }
         finally
         {
              System.Threading.Monitor.Exit(_samplingLock);
         }
       }
