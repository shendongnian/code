        public int GetBusinessDays(DateTime start, DateTime end, params DateTime[] bankHolidays)
        {
            int tld = (int)((end - start).TotalDays) + 1; //including end day
            int not_buss_day = 2 * (tld / 7); //Saturday and Sunday
            int rest = tld % 7; //rest.
            
            if (rest > 0)
            {
                int tmp = (int)start.DayOfWeek - 1 + rest;
                if (tmp == 6 || start.DayOfWeek == DayOfWeek.Sunday) not_buss_day++; else if (tmp > 6) not_buss_day += 2;
            }
            foreach (DateTime bankHoliday in bankHolidays)
            {
                DateTime bh = bankHoliday.Date;
                if (!(bh.DayOfWeek == DayOfWeek.Saturday || bh.DayOfWeek == DayOfWeek.Sunday) && (start <= bh && bh <= end))
                {
                    not_buss_day++;
                }
            }
            return tld - not_buss_day;
        }
