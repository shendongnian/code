       [XmlRoot(ElementName = "doc")]
        public class Account
        {
            [XmlElement("id")]
            public int Id { get; set; }
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlElement("note")]
            public string Note { get; set; }
            [XmlElement(ElementName = "list")]
            public List<BalanceListElement> Balance { get; set; }
            [XmlElement("label")]
            public string Label { get; set; }
            [XmlElement("country")]
            public int CountryId { get; set; }
        }
