    [System.Xml.Serialization.XmlRoot(Namespace="http://topLevelNS")]
    class MyClass
    {
        [System.Xml.Serialization.XmlElement(Namespace = "http://SomeOtherNS")]
        public int MyVar { get; set; }
    }
