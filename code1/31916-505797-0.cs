    public class Status
    {
        private int _code;
        private DateTime _lastUpdate;
        private object _sync = new object(); // single lock for both fields
    
        public int Code
        {
            get { lock (_sync) { return _code; } }
            set
            {
                lock (_sync) {
                    _code = value;
                }
    
                // Notify listeners
                EventHandler handler = Changed;
                if (handler != null) {
                    handler(this, null);
                }
            }
        }
    
        public DateTime LastUpdate
        {
            get { lock (_sync) { return _lastUpdate; } }
            set { lock (_sync) { _lastUpdate = value; } }
        }
    
        public event EventHandler Changed;
    }
