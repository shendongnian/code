    private double _NotamWidth;
    public double NotamWidth
    {
        get
        {
            return _NotamWidth;
        }
        set
        {
            _NotamWidth = value;
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(NotamWidth)));
            }
        }
    }
