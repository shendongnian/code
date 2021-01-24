    class MyResource : IDisposable
    {
      ~MyResource()
      {
        Dispose(false);
      }
    
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this); // don't finalize after the object has already been disposed of
      }
      protected void Dispose(bool disposing)
      {
        if(disposing)
        {
          // TODO: Dispose managed resources
        }
    
        // TODO: Dispose unmanaged resources
      }
    }
