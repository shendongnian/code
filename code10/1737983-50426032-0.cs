    public class Data
    {
        [XmlElement("Family")]
        public List<Family> Families { get; set; }
    }
    public class Family
    {
        [XmlElement("ID")]
        public int Id { get; set; }
        [XmlElement("Head_Model")]
        public string HeadModel { get; set; }
        [XmlElement("Version")]
        public List<int> Version { get; set; }
        [XmlElement("Use")]
        public List<string> Use { get; set; }
    }
