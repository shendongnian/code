    public sealed class CategoryHandler
    {
        private static CategoryHandler _instance = null;
        private static DateTime _expiry = DateTime.MinValue;
        private static readonly object _lock = new object();
        private CategoryHandler() { }
        public bool HasExpired
        {
            get
            {
                lock (_lock) { return (_expiry < DateTime.Now); }
            }
        }
        public static CategoryHandler Instance
        {
            get
            {
                lock (_lock)
                {
                    if (HasExpired)
                    {
                        _instance = new CategoryHandler(...);
                        _expiry = DateTime.Now.AddMinutes(60);
                    }
                    return _instance;
                }
            }
        }
    }
