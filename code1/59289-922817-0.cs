    public static class Options
    {
        private static int _myConfigInt;
        private static string _myConfigString;
        private static bool _initialized = false;
        private static object _locker = new object();
        private static void InitializeIfNeeded()
        {
            if (!_initialized) {
                lock (_locker) {
                    if (!_initialized) {
                        ReadConfiguration();
                        _initalized = true;
                    }
                }
            }
        }
        private static void ReadConfiguration() { // ... }
        public static int MyConfigInt {
            get {
                InitializeIfNeeded();
                return _myConfigInt;
            }
        }
        
        public static string MyConfigString {
            get {
                InitializeIfNeeded();
                return _myConfigstring;
            }
        }
        //..etc. 
    }
