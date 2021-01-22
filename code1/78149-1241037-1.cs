    public bool MonthsAreSequential(IList<DateTime> dates)
    {
        if (dates.Count < 2) return true;
        for (int i = 0; i < dates.Count - 1; i++)
        {
            var plusOne = dates[i].AddMonth(1);
            var nextMonth = dates[i + 1];
            if (plusOne .Year != nextMonth .Year 
                || plusOne .Month != nextMonth .Month)
                return false;
        }
        return true;
    }
