    public delegate void ThingToTryDeletage();
    
    public static void TryNTimes(ThingToTryDelegate, int N, int sleepTime)
    {
       while(true)
       {
          try
          {
            ThingToTryDelegate();
          } catch {
    
                if( --N == 0) throw;
              else Thread.Sleep(time);          
          }
    }
