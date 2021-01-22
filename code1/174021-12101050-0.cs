    [XmlIgnore]
    public Color BackColor { get; set; }
    [XmlElement("BackColor")]
    public int BackColorAsArgb
    {
        get { return BackColor.ToArgb();  }
        set { BackColor = Color.FromArgb(value); }
    }
