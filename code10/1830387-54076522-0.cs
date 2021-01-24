    public DateTime LoopDate()
    {
        DateTime[] TripDates = { DateTime.Parse("2019-01-01"), DateTime.Parse("2019-01-02"), DateTime.Parse("2019-01-03") };
        DateTime maxdate = TripDates.Max();
        return maxdate; //needs to return the maximum DateTime value from the loop 
    }
