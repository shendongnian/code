    [XmlRoot("AddJob")]
    public class AddJob
    {
        [XmlElement(ElementName = "AddJob")]
        public List<NestedAddJob> AddJobs { get; set; }
    }
    
    public class NestedAddJob
    {
        [XmlAttribute]
        public string RequestStatus { get; set; }
    
        [XmlAttribute]
        public string RequestMessage { get; set; }
    
        [XmlAttribute("UUID")]
        public string RipJobId { get; set; }
    }
