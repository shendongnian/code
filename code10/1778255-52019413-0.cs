    [XmlRoot]
    public class MyDto
    {
        [XMLElement]
        public string Name { get; set; }
        [XmlArray("UniqueNames")]
        [XmlArrayItem("string")]
        public List<string> UniqueNameStrings { get; set; }
        public MyDto() { }
    }
