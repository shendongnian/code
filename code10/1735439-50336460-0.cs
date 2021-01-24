        [XmlType("Product")]
        public class Product
        {
            [XmlAttribute(AttributeName = "pname")]
            public string Pname { get; set; }
            [XmlAttribute(AttributeName = "cpe")]
            public string Cpe { get; set; }
        }
    
        [XmlType("Vendor")]
        public class Vendor
        {
            [XmlElement(ElementName = "Product")]
            public List<Product> Product { get; set; }
            [XmlAttribute(AttributeName = "vname")]
            public string Vname { get; set; }
            [XmlAttribute(AttributeName = "cpe")]
            public string Cpe { get; set; }
        }
    
        [XmlType("VendorInfo")]
        public class VendorInfo
        {
            [XmlElement(ElementName = "Vendor")]
            public List<Vendor> Vendor { get; set; }
            [XmlAttribute(AttributeName = "xml:lang")]
            public string Lang { get; set; }
        }
    
        [XmlType("Status")]
        public class Status
        {
            [XmlAttribute(AttributeName = "feed")]
            public string Feed { get; set; }
            [XmlAttribute(AttributeName = "keyword")]
            public string Keyword { get; set; }
        }
    
        [XmlRoot(ElementName = "Result")]
        public class Result
        {
            [XmlElement(ElementName = "VendorInfo")]
            public VendorInfo VendorInfo { get; set; }
            [XmlElement(ElementName = "Status")]
            public Status Status { get; set; }
        }
