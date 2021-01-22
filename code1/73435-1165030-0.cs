    public string GetDateRangeString(DateTime dt1, DateTime dt2)
    {
       DateTimeFormatInfo info = new DateTimeFormatInfo();
       
       string format1;
       string format2;
       format2 = info.YearMonthPattern;
       format1 = dt1.Year == dt2.Year ? format1 = info.MonthDayPattern :
                                                   format2;
       return string.Format("{0} - {1}", dt1.ToString(format1), dt2.ToString(format2));
    }
