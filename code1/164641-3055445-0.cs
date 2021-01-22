    public static class DateTimeExtensions
    {
        public static string ToAgeString(this DateTime dob)
        {
            DateTime dt = DateTime.Now;
            int days = dt.Day - dob.Day;
            if (days < 0)
            {
                dt = dt.AddMonths(-1);
                days += DateTime.DaysInMonth(dt.Year, dt.Month);
            }
            int months = dt.Month - dob.Month;
            if (months < 0)
            {
                dt = dt.AddYears(-1);
                months += 12;
            }
            int years = dt.Year - dob.Year;
            return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                                 years, (years == 1) ? "" : "s",
                                 months, (months == 1) ? "" : "s",
                                 days, (days == 1) ? "" : "s");
        }
    }
