    [XmlType("response")]
    public class response
    {
    	[XmlElement("lst")]
        public List<lst> Lst { get; set; }
    }
    
    public class lst
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("int")]
        public List<Int> Int { get; set; }
    }
    
    public class Int
    {
    	[XmlAttribute(AttributeName="name")]
    	public string Name { get; set; }
    	[XmlText]
    	public string Text { get; set; }
    }
