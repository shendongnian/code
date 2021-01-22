    [XmlIgnore]
    public XmlNode NewValue { get; set; }
    [XmlElement("Dest")]
    public string NewValueString { get; set; }
    { 
        get { return NewValue.OuterXml; } // Edit: this property can't directly
        set { NewValue.OuterXml = value; } // set OuterXml
    }
