    [System.Xml.Serialization.XmlRootAttribute("Cars", Namespace = "", IsNullable = false)]
    public class Cars
    {
        [XmlArrayItem(typeof(Car))]
        public Car[] Car { get; set; }
    }
