    using System.Globalization;
    CultureInfo cultInfo = CultureInfo.CurrentCulture;
    int weekNumNow = cultInfo.Calendar.GetWeekOfYear(DateTime.Now,
                         cultInfo.DateTimeFormat.CalendarWeekRule,
                             cultInfo.DateTimeFormat.FirstDayOfWeek); 
