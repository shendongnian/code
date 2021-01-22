    class MyDisposableObject : IDisposable
    {
       public MyDisposableObject()
       {
       }
    
       ~MyDisposableObject()
       {
          Dispose(false);
       }
    
       private void Dispose(bool disposing)
       {
          if (disposing)
          {
             // Dispose of your managed resources here.
          }
    
          // Dispose of your unmanaged resources here.
       }
    
       void IDisposable.Dispose()
       {
          Dispose(true);
          GC.SuppressFinalize(this);
       }
    }
