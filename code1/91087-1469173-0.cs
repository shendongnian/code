    class Lazy<T> {
        
        readonly object sync = new object();
        Func<T> init;
        T result;
        bool initialized;
    
        public Lazy(Func<T> func) {
            this.init = func;
        }
    
        public T Value {
            get {
                bool changed = false; 
                lock (sync) {
                    if (!hasValue) {
                        result = this.init();
                        hasValue = true;
                    }
                }
                return this.result;
            }
        }
    }
