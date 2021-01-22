     // Get the weeks in a month
    
     DateTime date = DateTime.Today;
     // first generate all dates in the month of 'date'
     var dates = Enumerable.Range(1, DateTime.DaysInMonth(date.Year, date.Month)).Select(n => new DateTime(date.Year, date.Month, n));
     // then filter the only the start of weeks
     var weekends = from d in dates
                    where d.DayOfWeek == DayOfWeek.Monday
                    select d;
