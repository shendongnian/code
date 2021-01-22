    [XmlIgnore]
    public Immutable SomeProperty { get; set; }
    
    [XmlElement("SomeProperty")]
    public DummyImmutable SomePropertyXml
    {
        get { return new DummyImmutable(this.SomeProperty); }
        set { this.SomeProperty = value != null ? value.GetImmutable() : null; }
    }
