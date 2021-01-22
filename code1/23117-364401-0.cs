    [Serializable()]
    public class Car
    {
        [System.Xml.Serialization.XmlElement("StockNumber")]
        public string StockNumber { get; set; }
        [System.Xml.Serialization.XmlElement("Make")]
        public string Make { get; set; }
        [System.Xml.Serialization.XmlElement("Model")]
        public string Model { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("CarCollection")]
    public class CarCollection
    {
        [XmlArray("Cars")]
        [XmlArrayItem("Car", typeof(Car))]
        public Car[] Car { get; set; }
    }
