        public void Dispose() // Implement IDisposable
        {
            Dispose(true);
        #if DEBUG
            GC.SuppressFinalize(this);
        #endif
        }
    
        #if DEBUG
        ~MyClass() // the finalizer
        {
            Dispose(false);
        }
        #endif
