        [XmlRoot("Addresses")]
        public class Addresses
        {
            [XmlElement("Address")]
            public List<Address> AddressesList { get; set; }
        }
        public class Address
        {
            [XmlElement("AddressLine1")]
            public string AddressLine1 { get; set; }
            [XmlElement("AddressLine2")]
            public string AddressLine2 { get; set; }
            [XmlElement("Suburb")]
            public string Suburb { get; set; }
            [XmlElement("State")]
            public string State { get; set; }
            [XmlElement("PostCode")]
            public string PostCode { get; set; }
        }
