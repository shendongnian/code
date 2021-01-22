    [XmlRoot("RootElement"), XmlType("RootElement")]
    public class Foo {
        public string SomeProperty {get;set;}
        [XmlElement("ListElementEntry")]
        public List<Bar> Bars {get {return bars;}}
        private readonly List<Bar> bars = new List<Bar>();
    }
