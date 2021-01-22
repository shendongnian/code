    public int CalculateCoverageOne(DateTime dateCurrentDate, DateTime dateEffectiveDate, DateTime dateEffDateOne, DateTime dateEndDateOne)
    {
        TimeSpan ts;
        if (dateEffDateOne == DateTime.MinValue)
        {
            ts = TimeSpan.Zero;
        }
        else if (dateEffectiveDate <= dateEndDateOne)
        {
            ts = dateCurrentDate - dateEffDateOne;
        }
        else
        {
            ts = (dateEndDateOne - dateEffDateOne) + new TimeSpan(1, 0, 0, 0);
        }
        return ts.Days;
    }
