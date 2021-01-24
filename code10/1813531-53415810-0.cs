    [XmlRoot(ElementName = "Positions", Namespace = "http://www.sample-package.org")]
    public class Positions
    {
        [XmlElement(ElementName = "id", Namespace = "http://www.sample-package.org")]
        public string id { get; set; }
        [XmlElement(ElementName = "Tare_id", Namespace = "http://www.sample-package.org")]
        public string Tare_id { get; set; }
    }
    [XmlRoot(ElementName = "Head", Namespace = "http://www.sample-package.org")]
    public class OrderHeadUpload
    {
        [XmlElement(ElementName = "Number_confirm", Namespace = "http://www.sample-package.org")]
        public string Client_id { get; set; }
        [XmlElement(ElementName = "Number", Namespace = "http://www.sample-package.org")]
        public string Barcode_id { get; set; }
        [XmlElement(ElementName = "Positions")]
        public Positions positions;
    }
   
