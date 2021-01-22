    public struct Period
    {
        private readonly int days;
        public int Days { get { return days; } }
        private readonly int months;
        public int Months { get { return months; } }
        private readonly int years;
        public int Years { get { return years; } }
        public Period(int years, int months, int days)
        {
            this.years = years;
            this.months = months;
            this.days = days;
        }
        public Period WithDays(int newDays)
        {
            return new Period(years, months, newDays);
        }
        public Period WithMonths(int newMonths)
        {
            return new Period(years, newMonths, days);
        }
        public Period WithYears(int newYears)
        {
            return new Period(newYears, months, days);
        }
        public static DateTime operator +(DateTime date, Period period)
        {
            // TODO: Implement this!
        }
        public static Period Difference(DateTime first, DateTime second)
        {
            // TODO: Implement this!
        }
    }
