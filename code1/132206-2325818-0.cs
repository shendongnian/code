    public class DropInfo
    {
        [XmlArray("Drops")]
        [XmlArrayItem("DropItem")]
        public List<DropItem> Items { get; set; }
    
        [XmlAttribute]
        public int FinalDropCount { get; set; }
    }
    
    public class Location
    {
        public DropInfo DropInfo { get; set; }
    }
