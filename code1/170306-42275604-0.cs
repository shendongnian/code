    [XmlRoot("msg")]
    public class Message
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("action")]
        public string Action { get; set; }
    }
