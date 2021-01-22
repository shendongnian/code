    public static class DateTimeExtension
    {
        public static DateTime GetPreviousWeekDay(this DateTime currentDate, DayOfWeek dow)
        {
            int currentDay = (int)currentDate.DayOfWeek, gotoDay = (int)dow;
            return currentDate.AddDays(-7).AddDays(gotoDay-currentDay);
        }        
    }
