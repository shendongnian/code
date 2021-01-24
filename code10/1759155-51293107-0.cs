    [XmlRoot("event")]
    public class LenderXEvent
    {
        [XmlElement("type")]
        public string EventType { get; set; }
        [XmlElement("id")]
        public string EventID { get; set; }
        [XmlElement("data")]
        public LenderXData LXData { get; set; }
    }
