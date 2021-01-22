    [XmlRoot("ToobBars")]
    public class ToolBars : List<ToolbarSet>
    {
        
    }
    
    public class ToolbarSet
    {
        [XmlAttribute]
        public int id { get; set; }
        [XmlAttribute]
        public int buttonsCounter { get; set; }
        [XmlAttribute]
        public int width { get; set; }
    
        public List<ToolbarItem> ToolBarItems = new List<ToolbarItem>();
    }
    
    public class ToolbarItem
    {
        [XmlAttribute]
        public string command { get; set; }
        [XmlAttribute]
        public int id { get; set; }
        [XmlAttribute]
        public string icon { get; set; }
        [XmlAttribute]
        public bool visible { get; set; }
        [XmlAttribute]
        public bool enabled { get; set; }
    }
