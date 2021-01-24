    [XmlRoot(ElementName = "return")]
        public class EoriResponseModel
        {
            [XmlElement(ElementName = "requestDate")]
            public string RequestDate { get; set; }
            [XmlElement(ElementName = "result")]
            public List<Result> Result { get; set; }
        }
    
        [XmlRoot(ElementName = "result")]
        public class Result
        {
            [XmlElement(ElementName = "eori")]
            public string Eori { get; set; }
            [XmlElement(ElementName = "status")]
            public string Status { get; set; }
            [XmlElement(ElementName = "statusDescr")]
            public string StatusDescr { get; set; }
            [XmlElement(ElementName = "name")]
            public string Name { get; set; }
            [XmlElement(ElementName = "street")]
            public string Street { get; set; }
            [XmlElement(ElementName = "postalCode")]
            public string PostalCode { get; set; }
            [XmlElement(ElementName = "city")]
            public string City { get; set; }
            [XmlElement(ElementName = "country")]
            public string Country { get; set; }
        }
