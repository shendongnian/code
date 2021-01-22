    public class Config
    {
        private Config() 
        {
            this.Value = "foobarr";
        }
        private static object _syncLock = new object();
        private static Config _instance;
        public static Config Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                        _instance = new Config();
                    return _instance;
                }
            }
        }
        public string Value { get; private set; }
    }
