        [XmlRoot("properties")]
        public class LogProperties
        {
            [XmlElement("property")]
            public List<LogProperty> property { get; set; }
        }
        [XmlRoot("property")]
        public class LogProperty
        {
            [XmlAttribute("key")]
            public string key { get; set; }
            [XmlText]
            public string value { get; set; }
        }
