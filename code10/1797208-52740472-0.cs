    private static string[] GetWeekdays(DayOfWeek firstDayOfWeek)
    {
        string[] weekdays = new string[7];
        DateTime dateTime = DateTime.Now;
        while (dateTime.DayOfWeek != firstDayOfWeek)
        {
            // Find the next date with start day of week
            dateTime = dateTime.AddDays(1); 
        }
        for (int i = 0; i < 7; i++)
        {
            // Get day of week of current day, add 1 day, iterate 7 times.
            weekdays[i] = dateTime.DayOfWeek.ToString();
            dateTime = dateTime.AddDays(1);
        }
        return weekdays;
    }
