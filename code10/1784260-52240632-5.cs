    public partial class hashTreeThreadGroup : IGrouping {
        [XmlIgnore]
        public Dictionary<string, bool?> BoolProperties { get; } = new Dictionary<string, bool?>();
        [XmlIgnore]
        public Dictionary<string, long?> LongProperties { get; } = new Dictionary<string, long?>();
        [XmlIgnore]
        public Dictionary<string, string> StringProperties { get; } = new Dictionary<string, string>();
    }
    public partial class hashTreeHTTPSamplerProxy : IGrouping {
        [XmlIgnore]
        public Dictionary<string, bool?> BoolProperties { get; } = new Dictionary<string, bool?>();
        [XmlIgnore]
        public Dictionary<string, long?> LongProperties { get; } = new Dictionary<string, long?>();
        [XmlIgnore]
        public Dictionary<string, string> StringProperties { get; } = new Dictionary<string, string>();
    }
