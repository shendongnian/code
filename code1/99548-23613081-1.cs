        int BusinessDayDifference(DateTime Date1, DateTime Date2)
        {
            int Sign = 1;
            if (Date2 > Date1)
            {
                Sign = -1;
                DateTime TempDate = Date1;
                Date1 = Date2;
                Date2 = TempDate;
            }
            int BusDayDiff = (int)(Date1.Date - Date2.Date).TotalDays;
            if (Date1.DayOfWeek == DayOfWeek.Saturday)
                BusDayDiff -= 1;
            if (Date2.DayOfWeek == DayOfWeek.Sunday)
                BusDayDiff -= 1;
            int Week1 = GetWeekNum(Date1);
            int Week2 = GetWeekNum(Date2);
            int WeekDiff = Week1 - Week2;
            BusDayDiff -= WeekDiff * 2;
            BusDayDiff *= Sign;
            return BusDayDiff;
        }
        private int GetWeekNum(DateTime Date)
        {
            return (int)(Date.AddDays(-(int)Date.DayOfWeek).Ticks / TimeSpan.TicksPerDay / 7);
        }
