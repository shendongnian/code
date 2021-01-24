     private static void DisplayDayInfo(DateTime fromDate, DateTime toDate)
        {
            var numDays = toDate.Subtract(fromDate).Days;
            //Console.WriteLine("Total number of days from {0} to {1}: {2}\n", fromDate.ToShortDateString(), toDate.ToShortDateString(), numDays);
            //var dates = Enumerable.Range(0, numDays).Select(days => fromDate.AddDays(days)).ToArray();
            var holiday = Enumerable.Range(0, numDays).Select(days => fromDate.AddDays(days)).ToArray();
            foreach (DateTime dayOfWeek in holiday)
            {
                Console.WriteLine("{0} ", GetHoliDayCount(dayOfWeek));
            }
        }
