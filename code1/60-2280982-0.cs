    public static class DateTimeExtensions
    {
        public static int Age(this DateTime birthDate)
        {
            return Age(birthDate, DateTime.Now);
        }
        public static int Age(this DateTime birthDate, DateTime offsetDate)
        {
            int result;
            result = offsetDate.Year - birthDate.Year;
            if (offsetDate.DayOfYear < birthDate.DayOfYear) result--;
            return result;
        }
    }
