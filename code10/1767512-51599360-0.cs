        [XmlRootAttribute(ElementName = "element")]
        public class ElementRoot
        {
            [XmlAttribute("param")]
            public string paramAtribute;
            [XmlElement("param")]
            public string paramElement;
            [XmlAttribute("set")]
            public string setAtribute;
            [XmlElement("set")]
            public string setElement;
        }
