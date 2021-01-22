    class MyDisposableObject : IDisposable
    {
       public MyDisposableObject()
       {
       }
    
       ~MyDisposableObject()
       {
          Dispose(false);
       }
    
       private bool disposed;
       private void Dispose(bool disposing)
       {
          if (!this.disposed)
          {
              if (disposing)
              {
                 // Dispose of your managed resources here.
              }
    
              // Dispose of your unmanaged resources here.
              this.disposed = true;
           }
       }
       void IDisposable.Dispose()
       {
          Dispose(true);
          GC.SuppressFinalize(this);
       }
    }
