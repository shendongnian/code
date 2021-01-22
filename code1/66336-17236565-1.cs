    public class Simple
    {
        [XmlIgnore]
        public string Value { get; set; }
    }
    
    public class PathValue : Simple
    {
        [XmlAttribute("path")]
        new public string Value { 
                get { return base.Value != null ? base.Value : null; }
                set { base.Value = value != null ? value : null; }
        }
    }
    
    public class ObjectValue : Simple
    {
        [XmlAttribute("object")]
        new public string Value { 
                get { return base.Value != null ? base.Value : null; }
                set { base.Value = value != null ? value : null; }
        }
    }
