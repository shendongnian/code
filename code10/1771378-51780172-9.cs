    static void Main(string[] args)
        {
            RecurringJob.AddOrUpdate(() => Execute(), "0 6 * * *");// Run every morning @ 6
        }
        private static void Execute()
        {
            int currentWeekNumber = GetWeekNumberOfMonth(DateTime.Now);
            int dayNumber = (int)DateTime.Now.DayOfWeek;
            if ((currentWeekNumber == 1) && (dayNumber == (int)DayOfWeek.Wednesday))
                BackgroundJob.Enqueue(() => Console.WriteLine("Week 1 Job"));
            if ((currentWeekNumber == 2) && (dayNumber == (int)DayOfWeek.Monday))
                BackgroundJob.Enqueue(() => Console.WriteLine("Week 2 Job"));
            if ((currentWeekNumber == 3) && (dayNumber == (int)DayOfWeek.Thursday))
                BackgroundJob.Enqueue(() => Console.WriteLine("Week 3 Job"));
            if ((currentWeekNumber == 4) && (dayNumber == (int)DayOfWeek.Friday))
                BackgroundJob.Enqueue(() => Console.WriteLine("Week 4 Job"));
        }
        private static int GetWeekNumberOfMonth(DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            return (date - firstMonthMonday).Days / 7 + 1;
        }    
