        DateTime FromDate;
        DateTime ToDate;
        FromDate = DateTime.Parse("2001 Jan 01");
        ToDate = DateTime.Parse("2002 Mar 15");
    
        string s = DateAndTime.DateDiff (DateInterval.Month, FromDate,ToDate, FirstDayOfWeek.System, FirstWeekOfYear.System ).ToString();
