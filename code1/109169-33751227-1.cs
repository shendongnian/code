    private int GetWeekdayCountStupid(DayOfWeek dayOfWeek, DateTime begin, DateTime end)
        {
            if (begin < end)
            {
                var count = 0;
                var day = begin;
                while (day <= end)
                {
                    if (day.DayOfWeek == dayOfWeek)
                        count++;
                    day = day.AddDays(1);
                }
                return count;
            }
            return 0;
        }
