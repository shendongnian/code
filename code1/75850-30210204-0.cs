    public static class MyExtensions
    {
        public static IEnumerable EachDay(this DateTime start, DateTime end)
        {
            // Remove time info from start date (we only care about day). 
            DateTime currentDay = new DateTime(start.Year, start.Month, start.Day);
            while (currentDay <= end)
            {
                yield return currentDay;
                currentDay = currentDay.AddDays(1);
            }
        }
    }
