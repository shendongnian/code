    public static class DateTimeExtensions
    {
        public static int Age(this DateTime birthDate)
        {
            return Age(birthDate, DateTime.Now);
        }
        public static int Age(this DateTime birthDate, DateTime offsetDate)
        {
            int result=0;
            result = offsetDate.Year - birthDate.Year;
            if (offsetDate.DayOfYear < birthDate.DayOfYear)
            {
                  result--;
            }
            return result;
        }
    }
