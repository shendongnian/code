    public abstract class ConnectionAccessor : IDisposable
    {
        ~ConnectionAccessor()
        {
            Dispose(false);
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
        }
    }
