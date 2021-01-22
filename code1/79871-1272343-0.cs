    [XmlRoot("cars")]
    public class CarList
    {
        [XmlElement("car")]
        public CarCollection Cars { get; set; }
    }
