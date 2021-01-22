        {
            if (weekIndex > 4)
                return LastDayOfWeekInMonth(date, dow);
            DateTime newDate = new DateTime(date.Year, date.Month, 1);
            DayOfWeek newDow = newDate.DayOfWeek;
            int diff = dow - newDow;
            diff += ((weekIndex - 1) * 7);
            return newDate.AddDays(diff);
        }
