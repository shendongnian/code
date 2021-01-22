    [Serializable()]
    [System.Xml.Serialization.XmlRootAttribute("Cars", Namespace = "", IsNullable = false)]
    public class Cars
    {
        [XmlArrayItem(typeof(Car))]
        public Car[] Car { get; set; }
    }
.
    [Serializable()]
    public class Car
    {
        [System.Xml.Serialization.XmlElement()]
        public string StockNumber{ get; set; }
    
        [System.Xml.Serialization.XmlElement()]
        public string Make{ get; set; }
    
        [System.Xml.Serialization.XmlElement()]
        public string Model{ get; set; }
    }
