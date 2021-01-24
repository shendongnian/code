    public abstract class Widget
    {
        [XmlIgnore]
        public abstract string type { get;}
        [XmlAttribute]
        public string name { get; set; }
        [XmlIgnore]
        public string labelCation { get; set; }
        [XmlAttribute]
        public string text { get; set; }
        [XmlAttribute]
        public string dbpath { get; set; }
    }
