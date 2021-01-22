        public class Test
        {
            [XmlAttribute()]
            public string Attribute { get; set; }
            public string Description { get; set; }
            [XmlArray(ElementName = "Customers")]
            [XmlArrayItem(ElementName = "Customer")]
            public List<CustomerClass> blah { get; set; }
        }
