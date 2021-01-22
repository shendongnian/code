        //Code not tested thoroughly.
        private DateTime[] GetWeek(int month)
        {
            DateTime firstDayofMonth = new DateTime(DateTime.Now.Year, month, 1);
            if (firstDayofMonth.DayOfWeek == DayOfWeek.Sunday)
                return GetWeek(firstDayofMonth);
            else
            {
                DateTime sundayOfPreviousMonth = firstDayofMonth;
                do
                {
                    sundayOfPreviousMonth = sundayOfPreviousMonth.AddDays(-1);
                } while (sundayOfPreviousMonth.DayOfWeek != DayOfWeek.Sunday);
                return GetWeek(sundayOfPreviousMonth);
            }
        }
        private DateTime[] GetWeek(DateTime date)
        {
            if (date.DayOfWeek != DayOfWeek.Sunday)
                throw new ArgumentException("Invalid weekday.");
            DateTime[] week = new DateTime[7];
            for (int i = 0; i < week.Length; i++)
            {
                week[i] = date.AddDays(i);
            }
            return week;
        }
