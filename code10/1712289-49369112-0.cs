    DateTime _eventEndDateTime;
    
    public DateTime EventEndDate
    {
        get
        {
            return _eventEndDate;
        }
        set
        {
            SetProperty(ref _eventEndDate, value);
        }
    }
    public DateTime EventEndDateOnly
    {
        get
        {
            return _eventEndDate.Date;
        } 
        set
        {
            EventEndDate = value.Date + EventEndTimeOnly;
        }
    }
    public TimeSpan EventEndTimeOnly
    {
        get
        {
            return _eventEndDate.TimeOfDay;
        } 
        set
        {
            EventEndDate = EventEndDateOnly + value;
        }
    }
