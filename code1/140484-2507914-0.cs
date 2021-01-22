    [XmlIgnore]
    public bool Active { get; set; }
    [XmlAttribute("Active"), Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ActiveString {
        get { return Active ? "Yes" : "No"; }
        set {
            switch(value) {
                case "Yes": Active = true; break;
                case "No": Active = false; break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
