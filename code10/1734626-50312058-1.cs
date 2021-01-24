    [XmlRoot(ElementName = "data")]
    public class Data
    {
        [XmlAttribute(AttributeName = "someattributea")]
        public string Someattributea { get; set; }
        [XmlAttribute(AttributeName = "someattributeb")]
        public string Someattributeb { get; set; }
        [XmlAttribute(AttributeName = "someattributec")]
        public string Someattributec { get; set; }
        [XmlAnyAttribute]
        public XmlAttribute[] Attributes { get; set; }
        [XmlAnyElement]
        [XmlText] // Captures mixed content at the root level as well as child elements.
        public XmlNode[] ChildNodes { get; set; }
    }
