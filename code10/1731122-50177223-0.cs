    private DateTime _TheDate = new DateTime(2018, 05, 05); //<-- default date
    public DateTime TheDate
    {
        get { return _TheDate; }
        set
        {
            _TheDate = value;
            NotifyOfPropertyChange("TheDate");
        }
    }
