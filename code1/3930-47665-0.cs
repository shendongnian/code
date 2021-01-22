    class MyDisposable: IDisposable {
        public void Dispose() {
            lock(this) {
                if (disposed) {
                    return;
                }
    
                disposed = true;
            }
    
            GC.SuppressFinalize(this);
    
            // Do actual disposing here ...
        }
        
        private bool disposed = false;
    }
