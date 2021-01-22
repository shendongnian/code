    [Browsable(true)]
    [DisplayName("IPAddress")]
    public string IPAddressText
    {
        get { return this.IPAddress.ToString(); }
        set { this.IPAddress = IPAddress.Parse(value); }
    }
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IPAddress IPAddress
    {
        get;
        set;
    }
            
