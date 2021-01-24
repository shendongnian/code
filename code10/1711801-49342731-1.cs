    [XmlRoot(ElementName = "Attributes")]
    public class Attributes
    {
        [XmlElement(ElementName = "AddressAttribute")]
    
        public AddressAttribute[] AddressAttribute { get; set; }
    }
