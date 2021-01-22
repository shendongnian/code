    [XmlAttribute]
    public DateTime lastUpdatedDate { get; set; }
    public bool ShouldSerializelastUpdatedDate ()
    {
       return this.lastUpdatedDate != DateTime.MinValue; 
       // This prevents serializing the field when it has value 1/1/0001       12:00:00 AM
    }
