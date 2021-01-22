    public class B : IDisposable
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
        ~B()
        {
            Dispose(false);
        }
    }
