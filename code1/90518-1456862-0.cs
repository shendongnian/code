    [XmlRoot("Event")]
    public class Event
    {
    
        [XmlElement("DateTime")]
        public string DateTime 
        {
            get;
            set;
        }
    
        [XmlElement("EventType")]
        public EnumReportingEventType EventType
        {
            get;
            set;
        }
    
        [XmlElement("Result")]
        public EnumReportingResult Result
        {
            get;
            set;
        }
    
        [XmlElement("Provider")]
        public string Provider
        {
            get;
            set;
        }
    
        [XmlElement("ErrorMessage")]
        public string ErrorMessage
        {
            get;
            set;
        }
    
        [XmlElement("InnerException")]
        public string InnerException
        {
            get;
            set;
        }
    }
