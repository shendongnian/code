    public class MyClass
    {
    
      // Used as a lock context
      private readonly object myLock = new object();
    
      public void DoSomeWork()
      {
        lock (myLock)
        {
          // Critical code section
        }
      }
    }
