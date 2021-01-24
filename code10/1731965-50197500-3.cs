    string speed;
    public string Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed= value;
            NotifyPropertyChanged(nameof(Speed));
        }
    }
    string volt;
    public string Volt
    {
        get
        {
            return volt;
        }
        set
        {
            volt = value;
            NotifyPropertyChanged(nameof(Volt));
        }
    }
