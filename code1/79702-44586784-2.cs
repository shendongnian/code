    private long _contactNo;
    public long contactNo
    {
        get { return _contactNo; }
        set
        {
            if (value == _contactNo)
                return;
            _contactNo = value;
            OnPropertyChanged();
        }
    }
