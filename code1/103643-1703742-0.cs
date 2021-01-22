    public class Base
    {
        ~Base()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // so that Dispose(false) isn't called later
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                 // Dispose all owned managed objects
            }
            // Release unmanaged resources
        }
    }
