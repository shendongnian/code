    public static class Extensions
    {
        public static string ToCustomFormat(this DateTime date)
        {
            if (date.TimeOfDay < TimeSpan.FromMinutes(1))
            {
                return date.AddDays(-1).ToString("MM/dd/yyyy") + " 24:00";
            }
            return date.ToString("MM/dd/yyyy H:mm");
        }
    }
