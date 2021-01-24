        private static DateTime? GetHoliDayCount(DateTime holiday)
        {
            DateTime? holidayToReturn = null ;
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
            if (holidayState.Contains(holiday))
            {
                holidayToReturn = holiday;
            }
            return holidayToReturn;
        }
