    private int DaysLate(DateTime dateDue, DateTime dateReturned)
    {
        return getDayList(dateDue, dateReturned).Where(d => d.DayOfWeek != DayOfWeek.Sunday).Count();
    }
    
    private List<DateTime> getDayList(DateTime begin, DateTime end)
    {
        List<DateTime> dates = new List<DateTime>();
        DateTime counter = begin;
        while (counter <= end)
        {
            dates.Add(counter);
            counter = counter.AddDays(1);
        }
        return dates;
    }
