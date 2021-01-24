        public DateTime? CalculateSLADueDate(DateTime slaStartDateUTC, double slaDays, TimeSpan workdayStartUTC, TimeSpan workdayEndUTC)
        {
            if ((slaDays < 0)
            || (workdayStartUTC > workdayEndUTC))
            {
                return null;
            }
            var dueDate = slaStartDateUTC;
            var tsWorkdayHours = (workdayEndUTC - workdayStartUTC);
            var tsSlaCount = TimeSpan.FromHours(slaDays * ((workdayEndUTC - workdayStartUTC)).TotalHours);
            //get list of public holidays from in-memory cache
            var blPublicHoliday = new PublicHoliday();
            IList<BusObj.PublicHoliday> publicHolidays = blPublicHoliday.SelectAll();
            do
            {
                if ((dueDate.DayOfWeek == DayOfWeek.Saturday)
                || (dueDate.DayOfWeek == DayOfWeek.Sunday)
                || publicHolidays.Any(x => x.HolidayDate == dueDate.Date)
                || ((dueDate.TimeOfDay >= workdayEndUTC) && (dueDate.TimeOfDay < workdayStartUTC)))
                {
                    //jump to start of next day
                    dueDate = dueDate.AddDays(1);
                    dueDate = new DateTime(dueDate.Year, dueDate.Month, dueDate.Day, workdayStartUTC.Hours, workdayStartUTC.Minutes, workdayStartUTC.Seconds);
                }
                else if ((dueDate.TimeOfDay == workdayStartUTC) && (tsSlaCount >= tsWorkdayHours))
                {
                    //add a whole working day
                    dueDate = dueDate.AddDays(1);
                    tsSlaCount = tsSlaCount.Subtract(tsWorkdayHours);
                }
                else if (dueDate.TimeOfDay == workdayStartUTC)
                {
                    //end day - add remainder of time for final work day
                    dueDate = dueDate.Add(tsSlaCount);
                    tsSlaCount = tsSlaCount.Subtract(tsSlaCount);
                }
                else
                {
                    if(workdayEndUTC > dueDate.TimeOfDay)
                    {
                        //start day and still in business hours - add rest of today
                        tsSlaCount = tsSlaCount.Subtract(workdayEndUTC - dueDate.TimeOfDay);
                        dueDate = dueDate.Add(workdayEndUTC - dueDate.TimeOfDay);
                    }
                    if (tsSlaCount.Ticks > 0)
                    {
                        //if theres more to process - jump to start of next day
                        dueDate = dueDate.AddDays(1);
                        dueDate = new DateTime(dueDate.Year, dueDate.Month, dueDate.Day, workdayStartUTC.Hours, workdayStartUTC.Minutes, workdayStartUTC.Seconds);
                    }
                }
            }
            while (tsSlaCount.Ticks > 0);
            return dueDate;
        }
