        const int year = 2018;
        int month = DateTime.Now.Month;
        Calendar myCal = CultureInfo.InvariantCulture.Calendar;
        DayOfWeek[] accepted = new [] { DayOfWeek.Saturday, DayOfWeek.Friday };
        IEnumerable<DateTime> dateTimes = Enumerable.Range(1, DateTime.DaysInMonth(year, month)) 
            .Select(day => new DateTime(year, month, day))
            .Where(d => accepted.Contains(myCal.GetDayOfWeek(d)));
