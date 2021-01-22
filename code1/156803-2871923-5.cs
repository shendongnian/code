    public class DisposeImplementation : IDisposable
    {    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // get rid of managed resources
            }   
            // get rid of unmanaged resources
        }
    
        ~DisposeImplementation()
        {
            Dispose(false);
        }
    }
