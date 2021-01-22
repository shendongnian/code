    public DateTime? StartTime
    {
        get
        {
            return StartDate;
        }
        set
        {
            if (StartDate == null) StartDate = DateTime.Today;
            StartDate = StartDate.Value.Date.Add(value.HasValue ? value.Value.TimeOfDay: TimeSpan.Zero);
        }
    }
    public DateTime? StartDay
    {
        get { return StartDate; }
        set
        {
            DateTime BaseDate = value.HasValue ? value.Value : DateTime.MinValue;
            StartDate = BaseDate.Date.Add(StartDate.HasValue ? StartDate.Value.TimeOfDay : TimeSpan.Zero);
        }
    }
