    class MyClass: IDispose {
      int disposed = 0;
    
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
    
      public virtual void Dispose(bool disposing)
      {
         if (0 == Thread.InterlockedCompareExchange(ref disposed, 1, 0))
         {
           if (disposing)
           {
              // release managed resources here
           }
           // release unmanaged resources here
         }
      }
    
      ~MyClass()
      {
        Dispose(false);
      }
    } 
