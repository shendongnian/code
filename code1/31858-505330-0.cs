      public IEnumerable<DateTime> GetWeeks(DateTime date, DayOfWeek startDay)
      {
         var list = new List<DateTime>();
         DateTime first = new DateTime(date.Year, date.Month, 1);
         
         for (var i = first; i < first.AddMonths(1); i = i.AddDays(1))
         {
            if (i.DayOfWeek == startDay)
               list.Add(i);
         }
         return list;
      }
