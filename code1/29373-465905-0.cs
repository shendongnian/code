    public static int WeekNumber(this DateTime dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = 0;
            try
            {
                weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed,
               CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            }
            catch (Exception ex)
            {
                //TODO: Add error handling code
            }
    
            return weekNum;
        }
