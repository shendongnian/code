    [XmlRoot("A")]
    public class A
    {
        public string B { get; set; }
        public string C { get; set; }
        [XmlAnyElement()]
        public XmlElement D { get; set; }
    }
