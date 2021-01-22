    public class YourThreadSafeClass
    {
      private Object m_Lock = new Object();
      private Semaphore m_Semaphore = new Semaphore(1, 1);
    
      public void ToSearchPage()
      {
        lock (m_Lock)
        {
           // Actual work goes here.
        }
      }
    
      public bool AsyncToSearchPage()
      {
        // Throttle access using a semaphore
        if (m_Semaphore.WaitOne(0)) 
        {
          try 
          { 
            ManualResetEvent e = new ManualResetEvent(false);
            Thread t = new Thread(
                () =>
                {
                  // Acquire the lock here for the purpose of signalling the event
                  lock (m_Lock)
                  {
                    e.Set();
                    ToSearchPage(); // The lock will be acquired again here...thats ok
                  }
                }
              );
            t.Start();
            e.WaitOne(); // Wait for the lock to be acquired
            return true;
          }
          finally 
          {
            // Allow another thread to execute this method
            m_semaphore.Release();
          } 
        }
        return false;
      }
    }
