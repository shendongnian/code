    [XmlType("Items")]
    public class Items
    {
        [XmlAttribute("key")]
        public string key { get; set; }
        [XmlText()]
        public string value { get; set; }
    }
