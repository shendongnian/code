    [Serializable]
    [XmlRoot(Namespace = "http://www.bnr.ro/xsd", IsNullable = false)]
    public class DataSet
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
    }
    [Serializable]
    public class Header
    {
        public string Publisher { get; set; }
        [XmlElement(DataType = "date")]
        public DateTime PublishingDate { get; set; }
        public string MessageType { get; set; }
    }
    [Serializable]
    public class Body
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public string OrigCurrency { get; set; }
        [XmlElement("Cube")]
        public List<Cube> Cubes { get; set; }
    }
    [Serializable]
    public class Cube
    {
        [XmlElement("Rate")]
        public List<Rate> Rates { get; set; }
        [XmlAttribute("date")]
        public string Date { get; set; }
    }
    [Serializable]
    public class Rate
    {
        [XmlAttribute("currency")]
        public string Currency { get; set; }
        [XmlAttribute("multiplier")]
        public int Multiplier { get; set; }
        [XmlText]
        public decimal Value { get; set; }
    }
