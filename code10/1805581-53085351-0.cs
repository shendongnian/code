    private static void GetRecurrentDays(DateTime fromDate, DateTime untilDate, uint weeklyRecurrence, List<DayOfWeek> recurrenceDays)
    {
        var recurrenceDates = new List<DateTime>();
        var startingWeek = fromDate.DayOfYear / 7;
        for (var dt = fromDate; dt < untilDate; dt = dt.AddDays(1))
        {
            if (recurrenceDays.Any(day => day.Equals(dt.DayOfWeek)))
            {
                var lastDate = recurrenceDates.LastOrDefault(date => date.DayOfWeek.Equals(dt.DayOfWeek));
                
                // We multiply 7 days (a week) with weeklyRecurrence to 
                // calculate the appropiate date in which to add another day, 
                // calling with either 0 or 1 will calculate a weekly 
                // schedule
                if (lastDate.Equals(DateTime.MinValue) 
                    || weeklyRecurrence.Equals(0)
                    || ((dt - lastDate).Days % (7 * weeklyRecurrence)).Equals(0) )
                {
                    Console.WriteLine("hola");
                    recurrenceDates.Add(dt);
                }
            }
        }
    }
