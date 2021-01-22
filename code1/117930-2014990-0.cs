    public class Config
    {
        private Config() { }
        private Config _instance;
        public static Config Instance
        {
            get { return _instance; }
            protected set { _instance = value; }
        }
        public string Value { get; set; }
    }
