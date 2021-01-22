    public class BaseClass : IDisposable
    {
        private bool _disposed = false;
        ~BaseClass()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
        
            if (disposing)
            {
                //release managed resources
            }
            //release unmanaged resources
            
            _disposed = true;
        }
    }
    public void Derived : BaseClass
    {
        private bool _disposed = false;
    
        protected override void Dispose(bool disposing)
        {
            if (_disposed) 
                return;
            
            if (disposing)
            {
                //release managed resources
            }
            //release unmanaged resources
            
            base.Dispose(disposing);
            _disposed = true;
        }
