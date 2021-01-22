    public class Base : IDisposable
    {
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
              ReleaseManagedResources();
            }
            ReleaseUnmanagedResources();
            disposed = true;
        }
        
        // xml comments here describing whats going on lol
        protected virtual void ReleaseManagedResources(){}
        // xml comments here describing whats going on lol
        protected virtual void ReleaseUnmanagedResources(){}
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        ~Base()
        {
            Dispose(false);
        }
    }
