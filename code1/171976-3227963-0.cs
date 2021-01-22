    public IEnumerable<DateTime> GetAllDatesAndInitializeTickets(DateTime startingDate, DateTime endingDate)
    {
        if (endingDate < startingDate)
        {
            throw new ArgumentException("endingDate should be after startingDate");
        }
        var ts = endingDate - startingDate;
        for (int i = 0; i < ts.TotalDays; i++)
        {
            yield return startingDate.AddDays(i);
        }
    }
