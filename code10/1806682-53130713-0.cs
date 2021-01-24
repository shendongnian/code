            [XmlRoot(ElementName = "hubby")]
            public class Hubby
            {
                [XmlElement(ElementName = "id")]
                public string Id { get; set; }
            }
    
            [XmlRoot(ElementName = "person")]
            public class Person
            {
                [XmlElement(ElementName = "id")]
                public string Id { get; set; }
                [XmlElement(ElementName = "hubby")]
                public List<Hubby> Hubby { get; set; }
            }
    
            [XmlRoot(ElementName = "group")]
            public class Group
            {
                [XmlElement(ElementName = "person")]
                public List<Person> Person { get; set; }
            }
    
