            private static DateTime AddWithinWorkingHours(DateTime start, TimeSpan offset)
            {
                const int hoursPerDay = 8;
                const int startHour = 9;
    
                // Don't start counting hours until start time is during working hours
                if (start.TimeOfDay.TotalHours > startHour + hoursPerDay)
                    start = start.Date.AddDays(1).AddHours(startHour);
                if (start.TimeOfDay.TotalHours < startHour)
                    start = start.Date.AddHours(startHour);
    
                start = CheckTillNoLongerHoliday(start);
    
                if (start.DayOfWeek == DayOfWeek.Saturday)
                    start = start.AddDays(2);
                else if (start.DayOfWeek == DayOfWeek.Sunday)
                    start = start.AddDays(1);
    
                //Saving this proccessed date to check later if there are more holidays
                var dateAfterArranges = start;
    
                // Calculate how much working time already passed on the first day
                TimeSpan firstDayOffset = start.TimeOfDay.Subtract(TimeSpan.FromHours(startHour));
    
                // Calculate number of whole days to add
                int wholeDays = (int)(offset.Add(firstDayOffset).TotalHours / hoursPerDay);
    
                // How many hours off the specified offset does this many whole days consume?
                TimeSpan wholeDaysHours = TimeSpan.FromHours(wholeDays * hoursPerDay);
    
                // Calculate the final time of day based on the number of whole days spanned and the specified offset
                TimeSpan remainder = offset - wholeDaysHours;
    
                // How far into the week is the starting date?
                int weekOffset = ((int)(start.DayOfWeek + 7) - (int)DayOfWeek.Monday) % 7;
    
                // How many weekends are spanned?
                int weekends = (int)((wholeDays + weekOffset) / 5);
    
                //Get the final date without the holidays
                start = start.AddDays(wholeDays + weekends * 2).Add(remainder);
    
                //Check again if in this timeSpan there were any more holidays
                return InPeriodCheckHolidaysOnWorkingDays(dateAfterArranges, start);
            }
    
    
            private static DateTime CheckTillNoLongerHoliday(DateTime date)
            {
                if (DateSystem.IsPublicHoliday(date, CountryCode.PT) && !DateSystem.IsWeekend(date, CountryCode.PT))
                {
                    date = date.AddDays(1);
                    date = CheckTillNoLongerHoliday(date);
                }
    
                return date;
            }
    
    
            private static DateTime InPeriodCheckHolidaysOnWorkingDays(DateTime start, DateTime end)
            {
                var publicHolidays = DateSystem.GetPublicHoliday(2019, CountryCode.PT);
    
                var holidaysSpent = publicHolidays.Where(x => x.Date.Date >= start.Date && x.Date.Date < end.Date);
                foreach (var holiday in holidaysSpent)
                {
                    if (!DateSystem.IsWeekend(holiday.Date, CountryCode.PT))
                    {
                        end = end.AddDays(1);
                        if (DateSystem.IsWeekend(end, CountryCode.PT))
                        {
                            end = end.AddDays(2);
                        }
                    }
                }
    
                return end;
            }
