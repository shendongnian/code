    [XmlRoot]
    public class MyDto
    {
        [XMLElement]
        public string Name { get; set; }
        [XmlArray("UniqueNames"), XmlArrayItem("UniqueName")]
        public List<string> UniqueNameStrings { get; set; }
        public MyDto() { }
    }
