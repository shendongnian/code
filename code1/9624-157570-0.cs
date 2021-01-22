    public class Something
    {
      private object lockObj = new object();
    
      public SomethingReentrant()
      {
        lock(lockObj)    // Line A
        {
          // ...
         }
       }
    }
