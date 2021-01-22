    class MyObject : IDisposable {
    
        ~MyObject() {
            Dispose(false);
        }
    
        public void Dispose() {
            Dispose(true);
            GC.SupressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                // dispose of managed resources
            }
            // dispose of unmanaged resources
        }
    
    }
