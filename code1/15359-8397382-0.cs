    You could try this, if you want to get specific week days between two dates
        public List<DateTime> GetSelectedDaysInPeriod(DateTime startDate, DateTime endDate, List<DayOfWeek> daysToCheck)
        {
            var selectedDates = new List<DateTime>();
            if (startDate >= endDate)
                return selectedDates; //No days to return
            if (daysToCheck == null || daysToCheck.Count == 0)
                return selectedDates; //No days to select
            try
            {
                //Get the total number of days between the two dates
                var totalDays = (int)endDate.Subtract(startDate).TotalDays + 1;
                //So.. we're creating a list of all dates between the two dates:
                var allDatesQry = from d in Enumerable.Range(1, totalDays)
                                  select new DateTime(
                                                startDate.AddDays(d).Year,
                                                startDate.AddDays(d).Month,
                                                startDate.AddDays(d).Day);
                //And extracting those weekdays we explicitly wanted to return
                var selectedDatesQry = from d in allDatesQry
                                       where daysToCheck.Contains(d.DayOfWeek)
                                       select d;
                //Converting the IEnumerable to a List
                selectedDates = selectedDatesQry.ToList();
            }
            catch (Exception ex)
            {
                //Log error
                //...
                //And re-throw
                throw;
            }
            return selectedDates;
        }
