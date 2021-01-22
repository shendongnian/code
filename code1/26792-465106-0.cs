    public NameValueCollection CustomProperies { get; set; }
    protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
    {
        this.CustomProperies.Add(elementName, reader.ReadContentAsString());
        return false;
    }
