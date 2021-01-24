    [XmlRoot(ElementName = "SubClassification")]
    public class SubClassification
    {
        [XmlAttribute(AttributeName = "SubClassificationType")]
        public string SubClassificationType { get; set; }
    }
    [XmlRoot(ElementName = "Classification")]
    public class Classification
    {
        [XmlElement(ElementName = "SubClassification")]
        public SubClassification SubClassification { get; set; }
        [XmlAttribute(AttributeName = "ClassificationType")]
        public string ClassificationType { get; set; }
    }
    [XmlRoot(ElementName = "Reference")]
    public class Reference
    {
        [XmlAttribute(AttributeName = "ReferenceType")]
        public string ReferenceType { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    [XmlRoot(ElementName = "Component")]
    public class Component
    {
        [XmlElement(ElementName = "Classification")]
        public Classification Classification { get; set; }
        [XmlElement(ElementName = "Reference")]
        public Reference Reference { get; set; }
    }
    [XmlRoot(ElementName = "Root")]
    public class Root
    {
        [XmlElement(ElementName = "Component")]
        public List<Component> Component { get; set; }
    }
