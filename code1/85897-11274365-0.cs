    protected int _PropOne;
    public int PropOne
    {
        get
        {
            return _PropOne;
        }
        set
        {
            if(value != _PropOne)
                return;
            NotifyPropertyChanging("PropOne");
            _PropOne = value;
            NotifyPropertyChanged("PropOne");
        }
    }
