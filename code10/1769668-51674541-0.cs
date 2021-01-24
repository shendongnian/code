    [XmlRoot("customer")]
    public class Customer
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("address")]
        public string Address { get; set; }
    }
