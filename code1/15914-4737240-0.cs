    public MyClass: IDisposable
    {
    
        private bool _disposed = false;
    
        //Destructor
        ~MyClass()
        { Dispose(false); }
    
        public void Dispose()
        { Dispose(true); }
    
        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            GC.SuppressFinalize(this);
    
            /* actions to always perform */
    
            if (disposing) { /* actions to be performed when Dispose() is called */ }
    
            _disposed=true;
    }
