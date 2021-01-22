    public string Data { get; set; }
    [XmlIgnore]
    public string DataSpecified 
    { 
       get { return !String.IsNullOrEmpty(Data); }
       set { return; } //The serliazer requires a setter
    }
  
