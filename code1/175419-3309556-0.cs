    [XmlRoot("foo"), XmlType("foo")]
    [XmlInclude(typeof(SuperFoo))]
    public class Foo {
        public string X {get;set;}
        [XmlAttribute("y")]
        public int? Y {get;set;}
        [XmlElement("item")]
        public List<string> Items {get;set;}
    }
    public class SuperFoo : Foo {}
