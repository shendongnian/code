     private static void DisplayDayInfo(DateTime fromDate, DateTime toDate)
        {
            var numDays = toDate.Subtract(fromDate).Days;
            Console.WriteLine("Total number of days from {0} to {1}: {2}\n", fromDate.ToShortDateString(), toDate.ToShortDateString(), numDays);
            var dates = Enumerable.Range(0, numDays).Select(days => fromDate.AddDays(days)).ToArray();
            var holiday = Enumerable.Range(0, numDays).Select(days => fromDate.AddDays(days)).ToArray();
            foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine("{0} {1} ", dayOfWeek, GetDayCount(dates, dayOfWeek));
            }
            Console.WriteLine("****************************************************");
            foreach (DateTime dayOfWeek in holiday)
            {
                string holidayToWrite = GetHoliDayCount(dayOfWeek).ToString();
                if (holidayToWrite != "")
                    Console.WriteLine("{0} ", holidayToWrite);
            }
        }
