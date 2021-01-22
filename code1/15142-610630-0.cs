    [XmlIgnore]
    public double? SomeValue { get; set; }
      
    [XmlAttribute("SomeValue")] // or [XmlElement("SomeValue")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public double XmlSomeValue { get { return SomeValue.Value; } set { SomeValue= value; } }  
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool XmlSomeValueSpecified { get { return SomeValue.HasValue; } }
