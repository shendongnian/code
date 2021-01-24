    private bool? dhcpEnabled;
    
    public bool? DhcpEnabled
    {
        get => dhcpEnabled;
        set
        {
            if (dhcpEnabled != value)
            {
                dhcpEnabled = value;
                OnPropertyChanged(nameof(DhcpEnabled));
                OnPropertyChanged(nameof(DhcpDisabled));
            }
        }
    }
    
    public bool? DhcpDisabled
    {
        get => DhcpEnabled == false;
        set => DhcpEnabled = !value;
    }
