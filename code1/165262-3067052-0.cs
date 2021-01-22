            DateTime periodStart = new DateTime(2010, 10, 17);
            DateTime periodEnd = new DateTime(2010, 11, 14);
            const DayOfWeek FIRST_DAY_OF_WEEK = DayOfWeek.Monday;
            const DayOfWeek LAST_DAY_OF_WEEK = DayOfWeek.Sunday;
            const int DAYS_IN_WEEK = 7;
            DateTime firstDayOfWeekBeforeStartDate;
            int daysBetweenStartDateAndPreviousFirstDayOfWeek = (int)periodStart.DayOfWeek - (int)FIRST_DAY_OF_WEEK;
            if (daysBetweenStartDateAndPreviousFirstDayOfWeek >= 0)
            {
                firstDayOfWeekBeforeStartDate = periodStart.AddDays(-daysBetweenStartDateAndPreviousFirstDayOfWeek);
            }
            else
            {
                firstDayOfWeekBeforeStartDate = periodStart.AddDays(-(daysBetweenStartDateAndPreviousFirstDayOfWeek + DAYS_IN_WEEK));
            }
            DateTime lastDayOfWeekAfterEndDate;
            int daysBetweenEndDateAndFollowingLastDayOfWeek = (int)LAST_DAY_OF_WEEK - (int)periodEnd.DayOfWeek;
            if (daysBetweenEndDateAndFollowingLastDayOfWeek >= 0)
            {
                lastDayOfWeekAfterEndDate = periodEnd.AddDays(daysBetweenEndDateAndFollowingLastDayOfWeek);
            }
            else
            {
                lastDayOfWeekAfterEndDate = periodEnd.AddDays(daysBetweenEndDateAndFollowingLastDayOfWeek + DAYS_IN_WEEK);
            }
            int calendarWeeks = 1 + (int)((lastDayOfWeekAfterEndDate - firstDayOfWeekBeforeStartDate).TotalDays / DAYS_IN_WEEK);
