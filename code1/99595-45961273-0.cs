        // subtract the number of bank holidays during the time interval
        foreach (DateTime bankHoliday in bankHolidays)
        {
            DateTime bh = bankHoliday.Date;
            
            // Do not subtract bank holidays when they fall in the weekend to avoid double subtraction
            if (bh.DayOfWeek == DayOfWeek.Saturday || bh.DayOfWeek == DayOfWeek.Sunday)
                    continue;
            if (firstDay <= bh && bh <= lastDay)
                --businessDays;
        }
