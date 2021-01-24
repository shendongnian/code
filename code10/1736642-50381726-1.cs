    [XmlRoot(ElementName = "Platform")]
    public class Platform
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
    [XmlRoot(ElementName = "SymbolRoot")]
    public class SymbolRoot
    {
        [XmlElement(ElementName = "Platform")]
        public List<Platform> Platform { get; set; }
    }
    [XmlRoot(ElementName = "Specs")]
    public class Specs
    {
        [XmlElement(ElementName = "SymbolRoot")]
        public SymbolRoot SymbolRoot { get; set; }
    }
    [XmlRoot(ElementName = "Year")]
    public class Year
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "firstnoticedate")]
        public string Firstnoticedate { get; set; }
        [XmlAttribute(AttributeName = "lasttradedate")]
        public string Lasttradedate { get; set; }
        [XmlAttribute(AttributeName = "dateformat")]
        public string Dateformat { get; set; }
    }
    [XmlRoot(ElementName = "Month")]
    public class Month
    {
        [XmlElement(ElementName = "Year")]
        public List<Year> Year { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
    [XmlRoot(ElementName = "ContractMonths")]
    public class ContractMonths
    {
        [XmlElement(ElementName = "Month")]
        public Month Month { get; set; }
        [XmlAttribute(AttributeName = "firstnoticedaterule")]
        public string Firstnoticedaterule { get; set; }
        [XmlAttribute(AttributeName = "lasttradedaterule")]
        public string Lasttradedaterule { get; set; }
    }
    [XmlRoot(ElementName = "Commodity")]
    public class Commodity
    {
        [XmlElement(ElementName = "Specs")]
        public Specs Specs { get; set; }
        [XmlElement(ElementName = "ContractMonths")]
        public ContractMonths ContractMonths { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
    [XmlRoot(ElementName = "Grains")]
    public class Grains
    {
        [XmlElement(ElementName = "Commodity")]
        public List<Commodity> Commodity { get; set; }
    }
    [XmlRoot(ElementName = "Commodities")]
    public class Commodities
    {
        [XmlElement(ElementName = "Grains")]
        public Grains Grains { get; set; }
    }
