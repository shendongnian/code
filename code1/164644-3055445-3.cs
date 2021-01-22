    public static class DateTimeExtensions
    {
        public static string ToAgeString(this DateTime dob)
        {
            DateTime dt = DateTime.Today;
            int months = dt.Month - dob.Month;
            int years = dt.Year - dob.Year;
            if (dt.Day < dob.Day)
            {
                months--;
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }
            int days = (dt - dob.AddYears(years).AddMonths(months)).Days;
            return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                                 years, (years == 1) ? "" : "s",
                                 months, (months == 1) ? "" : "s",
                                 days, (days == 1) ? "" : "s");
        }
    }
