    [System.Xml.Serialization.XmlRootAttribute("Cars", Namespace = "", IsNullable = false)]
    public class Cars
    {
        [XmlElement("Car")]
        public Car[] Car { get; set; }
    }
