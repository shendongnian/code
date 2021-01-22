    public class DropList : List<DropItem>
    {
    }
    
    public class Location
    {
        public DropList DropList { get; set; }
    
        [XmlAttribute]
        public int FinalDropCount { get; set; }
    }
