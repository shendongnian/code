    public int hours
    {
        get
        {
            return _hours;
        }
        set
        {
            _hours = value;
            NotifyPropertyChanged(nameof(hours));
        }
    }
