    [Serializable]
    public class Thing
    {
        [XmlAttribute] 
        public string Name {get;set;}
    
        [XmlAnyElement]
        public XmlNode Document { get; set; }
    }
