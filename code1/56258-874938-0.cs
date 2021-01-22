    class MyClass: IDispose {
      bool disposed;
    
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
    
      public virtual void Dispose(bool disposing)
      {
         if (!disposed)
         {
           if (disposing)
           {
              // release managed resources here
           }
           // release unmanaged resources here
           disposed = true;
         }
      }
    
      ~MyClass()
      {
        Dispose(false);
      }
    }
