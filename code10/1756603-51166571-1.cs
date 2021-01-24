    public string CanContainNull
    {
        get
        {
            return _canContainNull;
        }
        set
        {
            _canContainNull = value;
            RaisePropertyChanged();
        }
    }
