    public string DelayTimeText
    {
        get
        {
            return _delayTimeText;
        }
        set
        {
            _delayTimeText = value; NotifyPropertyChanged();
        }
    } 
    public double DelayTime
    {
        get
        {
            if (double.TryParse( DelayTimeText, out double val ));
            _delayTime = val;
            return _delayTime;
        }
    }
