    public static int NumberOfWorkingDaysBetween2Dates(DateTime start,DateTime due,IEnumerable<DateTime> holidays)
            {
                var dic = new Dictionary<DateTime, DayOfWeek>();
                var totalDays = (due - start).Days;
                for (int i = 0; i < totalDays + 1; i++)
                {
                    if (!holidays.Any(x => x == start.AddDays(i)))
                        dic.Add(start.AddDays(i), start.AddDays(i).DayOfWeek);
                }
    
                return dic.Where(x => x.Value != DayOfWeek.Saturday && x.Value != DayOfWeek.Sunday).Count();
            } 
