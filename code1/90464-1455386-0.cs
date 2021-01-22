    [XmlRoot("cars")]
    public class Cars
    {
        [XmlElement("engineType")]
        public EngineType EngineType {get;set;}
    
        [XmlElement("makes")]
        public List<Make> Makes {get;set;}
    }
    
    public class EngineType
    {
        [XmlAttribute("name")]
        public string Name {get;set;}
    
        [XmlElement("part")]
        public Part Part {get;set;}
    }
    
    public class Make
    {
        [XmlAttribute("name")]
        public string Name {get;set;}
    
        [XmlAttribute("id")]
        public int ID {get;set;}
    
        [XmlElement("models")]
        public List<Model> Models {get;set;}
    }
    
    public class Model
    {
        [XmlAttribute("name")]
        public string Name {get;set;}
    
        [XmlAttribute("id")]
        public int ID {get;set;}
    }
