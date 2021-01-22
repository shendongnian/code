    public static DateTime AddBusinessDays(this DateTime date, int days)
    {
        for (int index = 0; index <= days; index++;)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    date.AddDays(3);
                    break;
                case DayOfWeek.Saturday:
                    date.AddDays(2);
                    break;
                default:
                    date.AddDays(1);
                    break;
             }
        }
        return date;
    }
