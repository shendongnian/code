    public class MyConfig
    {
        [XmlElement] 
        public string ConfigOption { get; set; }
        [XmlElement] 
        public MyUri SomeUri { get; set; }
    }
    public class MyUri
    {
        [XmlAttribute(Name="uri")]
        public Uri SomeUri { get; set; }
    }
