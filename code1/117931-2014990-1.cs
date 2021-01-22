    public class Config
    {
        private Config() { }
        private static Config _instance;
        public static Config Instance
        {
            get { return _instance; }
            private set { _instance = value; }
        }
        public string Value { get; set; }
    }
