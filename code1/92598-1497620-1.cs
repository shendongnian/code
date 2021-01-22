    System.Globalization.CultureInfo ci = // continued on next line -->
    System.Threading.Thread.CurrentThread.CurrentCulture;
    Int32 weekNo = ci.Calendar.GetWeekOfYear(
        new DateTime(2008,12,31),
        ci.DateTimeFormat.CalendarWeekRule,
        ci.DateTimeFormat.FirstDayOfWeek
    );
