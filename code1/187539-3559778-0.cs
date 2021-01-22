    [XmlIgnore]
    public SomeClass SomeProperty { get; set; }
    [XmlElement("SomeProperty")]
    public XmlSomeClass XmlSomeProperty
    {
        get { return XmlSomeClass.ToXml(SomeProperty); }
        set { SomeProperty = value.FromXml(); }
    }
