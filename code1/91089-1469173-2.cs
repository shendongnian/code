    class Lazy<T> {
        
        readonly object sync = new object();
        Func<T> init;
        T result;
        volatile bool initialized;
    
        public Lazy(Func<T> func) {
            this.init = func;
        }
    
        public T Value {
            get {
                
                if(initialized) return result;
                lock (sync) {
                    if (!initialized) {
                        result = this.init();
                        initialized = true;
                    }
                }
                return result;
            }
        }
    }
