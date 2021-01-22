       private System.EventHandler _Changed;
    
        private readonly object _EventLock = new object();
    
        public event System.EventHandler Changed {
            add {
                lock (_EventLock) {
                    _Changed += value;
                }
            }
            remove {
                lock (_EventLock) {
                    _Changed -= value;
                }
            }
        }
    
        protected virtual void OnChanged(System.EventArgs args) {
    
            System.EventHandler handler = _Changed;
            if (handler != null) {
                handler(this, args);
            }
        }
