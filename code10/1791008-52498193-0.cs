    [XmlRoot(ElementName = "report_metadata")]
    public class MetaData
    {
        [XmlElement(ElementName = "org_name")]
        public string Organisation { get; set; }
    }
    
    [XmlRoot(ElementName = "feedback")]
    public class Feedback
    {
        [XmlElement(ElementName = "report_metadata")]
        public MetaData MetaData { get; set; }
    }
