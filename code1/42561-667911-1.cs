    [XmlRoot("SomeXMLTag")]
    public class MyWrapper
    {
        [XmlElement("AreaFields")]
        public List<AreaFields> AreaFields { get; set; }
    }
    
    public class AreaFields
    {
        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<Fields> Fields { set; get; }
    
        [XmlAttribute]
        public int id { set; get; }
    }
    
    public class Fields
    {
        [XmlAttribute]
        public string Name { set; get; }
    }
