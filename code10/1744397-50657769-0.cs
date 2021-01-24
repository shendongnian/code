    [TestMethod]
    public void CreateSingletonInstance()
    {
        SiteStructure s = SiteStructure.GetInstance("Abc123");
        Debug.Print(s.Parameter); // outputs Abc123
        SiteStructure s2 = SiteStructure.GetInstance("Is it really a singleton?");
        Debug.Print(s2.Parameter); // still outputs Abc123
    }
    public sealed class SiteStructure
    {
        static SiteStructure _instance;
        static object _instance_Lock = new object();
        public static SiteStructure GetInstance(string parameter)
        {
            if (_instance == null)
            {
                lock (_instance_Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SiteStructure(parameter);
                    }
                }
            }
            return _instance;
        }
        private SiteStructure(string parameter)
        {
            // Initialize.
            Parameter = parameter;
        }
        public string Parameter { get; set; }
    }
