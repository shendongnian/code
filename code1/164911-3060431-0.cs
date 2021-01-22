    class Program
    {
        static void Main()
        {
            var when = DateTime.Today;
            DateTime fromEndOfNextMonth = when.AddMonthsRelativeToEndOfMonth(1);
        }
        
    }
    public static class DateTimeExtensions
    {
        public static DateTime AddMonthsRelativeToEndOfMonth(
                   this DateTime when, int months)
        {
            if (months == 0) return when;
            DateTime startOfNextMonth = when;
            int month = when.Month;
            while (startOfNextMonth.Month == month)
            {
                startOfNextMonth = startOfNextMonth.AddDays(1);
            }
            TimeSpan delta = startOfNextMonth - when;
            return startOfNextMonth.AddMonths(1) - delta;
        }
    }
