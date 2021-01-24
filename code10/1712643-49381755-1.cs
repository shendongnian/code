        [XmlRoot("RESPONSE")]
        public class Response {
            [XmlElement("RESULTS")]
            public Results Results {get;set;}
            [XmlElement("SOCCER")]
            public Soccer Soccer {get;set;}
        }
