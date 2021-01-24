        [XmlRoot("RESPONSE")]
        public class SoccerRoot {
            [XmlElement("SOCCER")]
            public Soccer Soccer {get;set;}
        }
        [XmlRoot("RESPONSE")]
        public class ResultsRoot {
            [XmlElement("RESULTS")]
            public Results Results {get;set;}
        }
