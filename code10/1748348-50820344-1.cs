    public static string GetConcentrationDays(DateTime fromDate)
    {
        switch (fromDate.DayOfWeek)
        {
            case DayOfWeek.Monday:
                return "Wednesday";
            case DayOfWeek.Tuesday:
                return "Thursday AND Friday";
            default:
                // For any other day, return the next day's day of week
                return fromDate.AddDays(1).DayOfWeek.ToString();
        }
    }
