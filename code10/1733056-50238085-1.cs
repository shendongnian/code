    public DateTime GetSaturdayDateOfWeek(int weekNumberInYear)
    {
        var myDate = new DateTime(DateTime.Now.Year, 1, 1);
        myDate = myDate.AddDays((weekNumberInYear -1)* 7);
        if (myDate.DayOfWeek < DayOfWeek.Saturday)
        {
            myDate = myDate.AddDays(DayOfWeek.Saturday - myDate.DayOfWeek);
        }
        if (myDate.DayOfWeek > DayOfWeek.Saturday)
        {
            myDate = myDate.AddDays(myDate.DayOfWeek - DayOfWeek.Saturday);
        }
        return myDate;
    }
