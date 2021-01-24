    public class XmlSerializable
    {
        [XmlIgnore]
        public ConcurrentBag<string> Array = new ConcurrentBag<string>();
        [XmlElement(ElementName = "Array")]
        public string[] ArrayXml { get { return Array.ToArray(); } set { Array = new ConcurrentBag<string>(value); } }
    }
