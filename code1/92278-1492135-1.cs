    int GetQuarterName(DateTime myDate)
    {
        return Math.Ceiling(myDate.Month / 3);
    }
    DateTime GetQuarterStartingDate(DateTime myDate)
    {
        return new DateTime(myDate.Year,(3*GetQuarterName(myDate))-2,1);
    }
