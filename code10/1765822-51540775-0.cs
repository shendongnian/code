    static IEnumerable<DateTime> GetDaysBetween(DateTime start, DateTime end)
            {
                for (DateTime i = start; i < end; i = i.AddDays(1))
                {
                    yield return i;
                }
            }
    
    DateTime startingDate = DateTime.Parse("07/25/2018");//TODO Insert variable from poted form 
    
    var numOfWeekends = GetDaysBetween(startingDate, startingDate.AddDays(7))
                .Where(d => d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday).Count();
    startingDate = startingDate.AddDays(numOfWeekends);
                Console.WriteLine(startingDate);
