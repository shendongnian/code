        static DateTime GetBusinessDay(int days)
        {
            var dateTime = DateTime.Now;
            bool run = true;
            int i = 0;
            while (run)
            {
                dateTime = dateTime.AddDays(1);
                if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }
                i++;
                if (i == 10)
                {
                    run = false;
                }
            }
            return dateTime;
        }
