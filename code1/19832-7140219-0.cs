    // Don't serialize this one
    [System.Xml.Serialization.XmlIgnore]
    public System.DateTimeOffset metadataDateTime
    {
        get { ... }
        set { ... }
    }
    
    
    // Serialize this one instead
    [System.Xml.Serialization.XmlAttribute("metadataDateTime")]
    public string metadataDateTimeXml
    {
        get { /* format metadataDateTime to custom format */ }
        set { /* parse metadataDateTime from custom format */ }
    }
