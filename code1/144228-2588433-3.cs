    [XmlIgnore]
    public Dictionary<string, Foo> Foos { get; set; }
    [XmlElement("Foos")]
    public XmlDictionaryEntryCollection SerializableFoos
    {
        get { return Foos.AsXmlDictionary(); }
        set { Foos = value.Dictionary; }
    }
