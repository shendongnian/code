    private static int GetHoliDayCount(IEnumerable<DateTime> holiday, DayOfWeek dayOfWeek)
        {
            var yearsGroup = holiday.GroupBy(x => x.Year);
            List<DateTime> daysToAdd = new List<DateTime>();
            DateTime[] holidayState = null;
            foreach (var year in yearsGroup)
            {
                List<DateTime> days = holiday.Where(x => x.Year == Convert.ToInt32(year.Key)).ToList();
                holidayState = new DateTime[]
                  {
                new DateTime(Convert.ToInt32(year.Key), 1, 1),
                new DateTime(Convert.ToInt32(year.Key), 1, 26),
                new DateTime(Convert.ToInt32(year.Key), 3, 30),
                new DateTime(Convert.ToInt32(year.Key), 3, 31),
                new DateTime(Convert.ToInt32(year.Key), 4, 1),
                new DateTime(Convert.ToInt32(year.Key), 4, 2),
                new DateTime(Convert.ToInt32(year.Key), 4, 25),
                new DateTime(Convert.ToInt32(year.Key), 5, 7),
                new DateTime(Convert.ToInt32(year.Key), 8, 15),
                new DateTime(Convert.ToInt32(year.Key), 9, 1),
                new DateTime(Convert.ToInt32(year.Key), 12, 25),
                new DateTime(Convert.ToInt32(year.Key), 12, 26)
                      };
                foreach (DateTime day in days)
                {
                    if (holidayState.Contains(day))
                    {
                        daysToAdd.Add(day);
                    }
                }
            }
            holiday = daysToAdd;           
            return holiday == null ? 0 : holidayState.Count(date => date.DayOfWeek == dayOfWeek);
        }
