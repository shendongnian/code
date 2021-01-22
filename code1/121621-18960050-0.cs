    [XmlIgnore]
    public System.Version Version { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
    public string version 
    {
        get 
        {
            if (this.Version == null)
                return string.Empty;
            else
                return this.Version.ToString();
        }
        set 
        {
            if(!String.IsNullOrEmpty(value))
               this.Version = new Version(value);
        } 
    }
