    public static int CalculateBusinessDaysInRange(this DateTime startDate, DateTime endDate, params DateTime[] holidayDates)
    {
        endDate = endDate.Date;
        if(startDate > endDate)
            throw new ArgumentException("The end date can not be before the start date!", nameof(endDate));
        int accumulator = 0;
        DateTime itterator = startDate.Date;
        do 
        {
            if(itterator.DayOfWeek != DayOfWeek.Saturday && itterator.DayOfWeek != DayOfWeek.Sunday && !holidayDates.Any(hol => hol.Date == itterator))
            { accumulator++; }
        } 
        while((itterator = itterator.AddDays(1)).Date <= endDate);
        return accumulator
    }
