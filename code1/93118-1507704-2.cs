    [XmlType("apple"), XmlRoot("apple")]
    public class Apple {
        [XmlAttribute("variety")]
        public string Variety {get;set;}
        [XmlAttribute("weight")]
        public decimal Weight {get;set;}
        // etc
    }
