    @{
        int currentMonth = DateTime.Now.Month;
        int currentYear = DateTime.Now.Year;
        DateTime firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        int daysInCurrentMonth = DateTime.DaysInMonth(firstDay.Year, firstDay.Month);
        DateTime lastDay = new DateTime(currentYear, currentMonth, daysInCurrentMonth);
        // Sunday casted to int gives 0 but that will not work for us, we need 7 to be able to calculate number of empty cells correctly
        int dayOfWeekFirst = ((int)firstDay.DayOfWeek > 0) ? (int)firstDay.DayOfWeek : 7;
        int dayOfWeekLast = ((int)lastDay.DayOfWeek > 0) ? (int)lastDay.DayOfWeek : 7;
    }
