    int day=0,month=0,year=0;
    DateTime smallDate = Convert.ToDateTime(string.Format("{0}", "01.01.1900"));
    DateTime bigDate = Convert.ToDateTime(string.Format("{0}", "05.06.2019"));
    TimeSpan timeSpan = new TimeSpan();
    //timeSpan is diff between bigDate and smallDate as days
    timeSpan = bigDate - smallDate;
    //year is totalDays / 365 as int
    year = timeSpan.Days / 365;
    //smallDate.AddYears(year) is closing the difference for year because we found the year variable
    smallDate = smallDate.AddYears(year);
    //again subtraction because we don't need the year now
    timeSpan = bigDate - smallDate;
    //month is totalDays / 30 as int
    month = timeSpan.Days / 30;
    //smallDate.AddMonths(month) is closing the difference for month because we found the month variable
    smallDate = smallDate.AddMonths(month);
    if (bigDate > smallDate)
    {
        timeSpan = bigDate - smallDate;
        day = timeSpan.Days;
    }
    //else it is mean already day is 0
