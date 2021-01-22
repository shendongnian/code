    public string Data { get; set; }
    [XmlIgnore]
    public bool DataSpecified 
    { 
       get { return !String.IsNullOrEmpty(Data); }
       set { return; } //The serializer requires a setter
    }
