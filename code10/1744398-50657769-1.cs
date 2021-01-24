    [TestMethod]
    public void CreateSingletonInstance()
    {
        SiteStructure s = SiteStructure.GetInstance("Abc123");
        Debug.Print(s.Parameter); // outputs Abc123
        SiteStructure s2 = SiteStructure.GetInstance("Is it really a singleton?");
        Debug.Print(s2.Parameter); // outputs Is it really a singleton?
        SiteStructure s3 = SiteStructure.GetInstance("Abc123");
        Debug.Print(s3.Parameter); // outputs Abc123
        Assert.AreNotEqual(s, s2); // Check to make sure they are different instances
        Assert.AreEqual(s, s3); // Check to make sure they are the same instance
    }
    public sealed class SiteStructure
    {
        static Dictionary<string, SiteStructure> _siteStructures = new Dictionary<string, SiteStructure>();
        static object _instance_Lock = new object();
        public static SiteStructure GetInstance(string parameter)
        {
            if (!_siteStructures.ContainsKey(parameter))
            {
                lock (_instance_Lock)
                {
                    if (!_siteStructures.ContainsKey(parameter))
                    {
                        _siteStructures.Add(parameter, new SiteStructure(parameter));
                    }
                }
            }
            return _siteStructures[parameter];
        }
        private SiteStructure(string parameter)
        {
            // Initialize.
            Parameter = parameter;
        }
        public string Parameter { get; set; }
    }
