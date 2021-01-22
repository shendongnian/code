    [XmlArray(ElementName = nameof(Metadata), IsNullable = true)]
    public string[] MetadataArray { get; set; }
    
    [XmlIgnore]
    public List<string> Metadata
    {
        get => this.MetadataArray?.ToList();
        set => this.MetadataArray = value?.ToArray();
    }
