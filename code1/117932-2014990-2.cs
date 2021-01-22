    public class Config
    {
        private Config() 
        {
            this.Value = "foobarr";
        }
        private static Config _instance;
        public static Config Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Config();
                return _instance;
            }
        }
        public string Value { get; private set; }
    }
