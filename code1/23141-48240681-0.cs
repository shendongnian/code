    [XmlRoot("Cars")]
    public class XmlData
    {
        [XmlElement("Car")]
        public List<Car> Cars{ get; set; }
    }
    
    public class Car
    {
        public string StockNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
