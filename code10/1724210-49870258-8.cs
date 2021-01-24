     private static int GetHoliDayCount(IEnumerable<DateTime> holiday, DayOfWeek dayOfWeek)
        {
            List<DateTime> days = holiday.ToList(); //convert this to list
            List<DateTime> daysToAdd = new List<DateTime>(); //have a list as container for the holidays after the comparison.
            DateTime[] holidayState = new DateTime[]
            {
                new DateTime(DateTime.Now.Year, 1, 1),
                new DateTime(DateTime.Now.Year, 1, 26),
                new DateTime(DateTime.Now.Year, 3, 30),
                new DateTime(DateTime.Now.Year, 3, 31),
                new DateTime(DateTime.Now.Year, 4, 1),
                new DateTime(DateTime.Now.Year, 4, 2),
                new DateTime(DateTime.Now.Year, 4, 25),
                new DateTime(DateTime.Now.Year, 5, 7),
                new DateTime(DateTime.Now.Year, 8, 15),
                new DateTime(DateTime.Now.Year, 9, 1),
                new DateTime(DateTime.Now.Year, 12, 25),
                new DateTime(DateTime.Now.Year, 12, 26)
            };
            foreach (DateTime day in days)
            {
                if (holidayState.Contains(day))
                {
                    daysToAdd.Add(day);
                }
            }
            holiday = daysToAdd;
            
            return holiday == null ? 0 : holidayState.Count(date => date.DayOfWeek == dayOfWeek);
        }
