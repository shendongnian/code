    [XmlType(TypeName="day")]
    public class Day
    {
        [XmlAttribute("p")]
        public string P { get; set; }
    }
    [XmlRoot("someObject")]
    public class SomeObject
    {
        [XmlArray("days")]
        public List<Day> Days { get; set; }
    }
