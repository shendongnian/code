     public abstract class DisposableType: IDisposable
      {
        bool disposed = false;
    
        ~DisposableType()
        {
          if (!disposed) 
          {
            disposed = true;
            Dispose(false);
          }
        }
    
        public void Dispose()
        {
          if (!disposed) 
          {
            disposed = true;
            Dispose(true);
            GC.SuppressFinalize(this);
          }
        }
    
        public void Close()
        {
          Dispose();
        }
    
        protected virtual void Dispose(bool disposing)
        {
          if (disposing) 
          {
            // managed objects
          }
          // unmanaged objects and resources
        }
      }
