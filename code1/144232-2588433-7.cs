    [XmlIgnore]
    public Dictionary<string, Foo> Foos { get; set; }
    [XmlElement("Foos")]
    public XmlDictionaryEntryCollection SerializableFoos
    {
        get { return Foos.AsXmlSerializable(); }
        set { Foos = value.Dictionary; }
    }
