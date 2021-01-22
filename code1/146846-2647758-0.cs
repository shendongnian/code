    private TimeZoneInfo edt = TimeZoneInfo.FindSystemTimeZoneById("EDT");
    private DateTime utcDate = new DateTime(2010, 1, 1);
    public DateTime LocalDate 
    {
        get { return TimeZoneInfo.ConvertTime(utcDate, edt); }
    }
