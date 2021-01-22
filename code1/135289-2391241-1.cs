    private DateTime _MyDate;
    public DateTime? MyDate
    {
        get { return _MyDate; }
        set { _MyDate = value.GetValueOrDefault(); }
    }
