    public DateRange()
    {
        type = "xsd:dateTime";
    }
    
    [XmlAttribute(Namespace = "http://www.w3.org/2001/XMLSchema-instance", AttributeName = "type")]
    public string type { get; set; }
