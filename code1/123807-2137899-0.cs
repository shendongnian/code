    [XmlRoot]
    public class MyMetadata
    {
    
        [XmlElement]
        public Group[] Groups { get; set; }
    
    }
    
    public class Group
    {
    
        [XmlAttribute]
        public string Name { get; set; }
    
        [XmlAttribute]
        public int SomeNumber { get; set; }
    
        [XmlElement]
        public Widget[] Widgets { get; set; }
    
    }
    
    public class Widget
    {
        ...
    }
