    [XmlIgnore]
    public Uri Uri {get;set;}
    [XmlAttribute("uri")]
    [Browsable(false), EditorBrowsable((EditorBrowsableState.Never)]
    public string UriString {
        get {return Uri == null ? null : Uri.ToString();}
        set {Uri = value == null ? null : new Uri(value);}
    }
