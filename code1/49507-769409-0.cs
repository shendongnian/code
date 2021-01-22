    public DateTime GetDayOfWeek(int dayOfWeek)
    {
        if (dayOfWeek < 0 || dayOfWeek > 6) throw new ArgumentOutOfRangeException(...);
    
        // 4 January 2009 was a Sunday
        return new DateTime(2009,1,4).AddDays(dayOfWeek);
    }
