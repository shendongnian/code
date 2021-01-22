    public class Simple
    {
        [XmlIgnore]
        public string Value { get; set; }
    }
    
    public class PathValue : Simple
    {
        [XmlAttribute("path")]
        public string Path { 
                get { return base.Value != null ? base.Value : null; }
                set { base.Value = value != null ? value : null; }
        }
    }
    
    public class ObjectValue : Simple
    {
        [XmlAttribute("object")]
        public string Object { 
                get { return base.Value != null ? base.Value : null; }
                set { base.Value = value != null ? value : null; }
        }
    }
