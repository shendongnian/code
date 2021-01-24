    public class DCTRequest
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "schemaLocation", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        public GetQuote GetQuote { get; set; }
    }
    public class GetQuote
    {
        public Request Request { get; set; }
    }
    public class Request
    {
        public ServiceHeader ServiceHeader { get; set; }
    }
    public class ServiceHeader
    {
        public DateTime MessageTime { get; set; }
        public string MessageReference { get; set; }
        public string SideID { get; set; }
        public string Password { get; set; }
    }
