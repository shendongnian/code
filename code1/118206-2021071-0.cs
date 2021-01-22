    [XmlIgnore]
    public XmlNode NewValue { get; set; }
    [XmlElement("Dest")]
    public string NewValueString 
    { 
        get { return NewValue.OuterXml; }
        set { NewValue.OuterXml = value; }
    }
