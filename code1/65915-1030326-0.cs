    void SetDays(params DayOfWeek[] daysToSet)
    {
        if (daysToSet == null || !daysToSet.Any())
            throw new ArgumentNullException("daysToSet");
        foreach (DayOfWeek day in daysToSet)
        {
            // if( day == DayOfWeek.Monday ) etc ....
        }
    }
    SetDays( DayOfWeek.Monday, DayOfWeek.Sunday );
