    public class Response
    {
        [XmlElement("OrganisationData")] 
        public OrganisationData OrganisationData { get; set; }
    	
    	[XmlElement("TransactionData")] 
        public TransactionData TransactionData { get; set; }
    	
    	[XmlElement("Error")] 
        public Error Error { get; set; }
    	
    	[XmlElement("NewTag")] 
        public NewTag NewTag { get; set; }
    }
