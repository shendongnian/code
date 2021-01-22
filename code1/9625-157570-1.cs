    public class Something
    {
      private readonly object lockObj = new object();
    
      public SomethingReentrant()
      {
        lock(lockObj)    // Line A
        {
          // ...
         }
       }
    }
