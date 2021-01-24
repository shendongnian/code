    using System.Globalization;
    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
    
    var week = dt.AsEnumerable().GroupBy(row => 
                      dfi.Calendar.GetWeekOfYear(Convert.ToDateTime(row["Date"]), dfi.CalendarWeekRule, 
                                                 dfi.FirstDayOfWeek))
                  .Select(g => new
                  {
                      Date = g.First()["Date"].ToString(),
                  }).ToList();
