        [XmlRoot("Network")]
        public class Network
        {
            [XmlArrayItem("ROUTE")]
            [XmlArray("ROUTES")]
            public List<ROUTE> ROUTES { get; set; }
        }
