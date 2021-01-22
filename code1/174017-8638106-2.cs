    // Color as tag
    [XmlElement(Type = typeof(XmlColor))]
    public Color ColorAsTag { get; set; }
    // Color as attribute
    private Color ColorAsAttribute { get; set; }
    [XmlAttribute("ColorAsAttribute")]
    public string ColorAsAttribute_XmlSurrogate
    {
        get { return XmlColor.FromColor(ColorAsAttribute); }
        set { ColorAsAttribute = XmlColor.ToColor(value); }
    }
