    public DateTime Timestamp
    {
        get { return _timestampProvider??new SystemTimestampProvider(); }
        set { _timestampProvider = value; }
    }
