    public List<int> GetWeeksInYear(int year)
    {
        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
        DateTime date1 = new DateTime(year, 12, 31);
        System.Globalization.Calendar cal = dfi.Calendar;
        int weeks = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);
        List<int> weekList = new List<int>();
        for (int i = 1; i <= weeks; i++)
        {
            weekList.Add(i);
        }
        return weekList;
    }
