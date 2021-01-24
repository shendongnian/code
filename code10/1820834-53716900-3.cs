    [XmlRoot("root")]
    public class Info
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlElement("dealId")]
        public string DealId { get; set; }
        [XmlElement("dealDetailId")]
        public string DealDetailId { get; set; }
        [XmlElement("localeId")]
        public string LocaleId { get; set; }
    }
