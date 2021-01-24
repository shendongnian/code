        public static DateTime LastThursdayOfTheMonth(int month, int year)
        {
            DateTime date = new DateTime(year, month, DateTime.DaysInMonth(year, year));
            while (date.DayOfWeek != DayOfWeek.Thursday)
            {
                date = date.AddDays(-1);
            }
            return date;
        }
