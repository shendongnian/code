    class BarId
    {
        [XmlText()]
        public int Content {get; set;}
        
        [XmlAttribute()]
        public string BarString {get; set;}
    }
    
    public class Foo{
        public BarId BarId {get; set;}
    }
