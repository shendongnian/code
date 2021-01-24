    public TimeSpan Start
    {
        get => start.Value.TimeOfDay;
        set => start.Value = start.Value.Date + value;
    }
    public TimeSpan Lunch
    {
        get => lunch.Value.TimeOfDay;
        set => lunch.Value = lunch.Value.Date + value;
    }
    public TimeSpan End
    {
        get => end.Value.TimeOfDay;
        set => end.Value = end.Value.Date + value;
    }
