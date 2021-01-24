       for (DateTime date = start; date < end; date = date.AddMonths(1))
       {
           DateTime this_date_start = new DateTime(date.Year, date.Month, 1);
           DateTime this_date_end = this_date_start.AddMonths(1).AddDays(-1);
           TimeSpan duration = this_date_end.Subtract(start);
           Console.WriteLine("duration " + date.Month + " = " + duration.Days  + "days");
       }
       
