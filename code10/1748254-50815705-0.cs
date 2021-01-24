    [XmlRoot(ElementName = "result")]
    public class Result
    {
        // no need XmlElement attribute
        public ServiceComplex ServiceComplex { get; set; }
        // no need XmlElement attribute
        public string ServiceSimple { get; set; }
        // other properties
    }
    // no need XmlRoot attribute
    public class ServiceComplex
    {
        [XmlElement(ElementName = "min_amount")]
        public string Min_amount { get; set; }
        [XmlElement(ElementName = "max_amount")]
        public string Max_amount { get; set; }
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
    }
