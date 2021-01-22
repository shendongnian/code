    [XmlIgnore]
    public int[, ,] Data { get; set; }
    [XmlElement("Data"), Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] DataDto
    {
        get { /* flatten from Data */ }
        set { /* expand into Data */ }
    } 
