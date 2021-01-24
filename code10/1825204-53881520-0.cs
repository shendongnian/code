    bool _value;
    public bool value{
        get { return _value; }
        set
        {
            _value = value;
            NotifyPropertyChanged();
        }
    }
