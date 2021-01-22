    public class SimpleCleanup : IDisposable
    {
        private bool disposed = false;
    
        public bool IsDisposed
        {
           get
           {
              return disposed;
           }
        }
    
        public SimpleCleanup()
        {
            this.handle = /*...*/;
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                   // free only managed resources here
                }
    
                // free unmanaged resources here
                disposed = true;
            }
        }
    
        public void Dispose()
        {
            Dispose(true);
        }
    }
