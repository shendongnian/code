    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
    Calendar cal = dfi.Calendar;
    //just to make formatting on SO better
    var whereClause = ClickStatistics
             .Where(i => i.LogDate.Year == selectedYear && i.Statement.Deleted == false).ToList();
    var WeekCountQuery = from c in whereClause
                         group c by 
                         cal.GetWeekOfYear(c.LogDate, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) 
                         into grp
                         select new
                         {
                              Week = grp.Key,
                              Clicks = grp.Count(),
                         };
