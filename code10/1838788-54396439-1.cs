     [XmlRoot(ElementName = "MydocumentName")]
        public class MydocumentName
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }
        [XmlRoot(ElementName = "Group")]
        public class Group
        {
            [XmlElement(ElementName = "MydocumentName")]
            public MydocumentName MydocumentName { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }
        [XmlRoot(ElementName = "MYDOCUMENT")]
        public class MYDOCUMENT
        {
            [XmlElement(ElementName = "Group")]
            public Group Group { get; set; }
        }
