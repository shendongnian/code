    var datesgrouped = from d in dates
                       group d by d.DayOfWeek into grouped
                       select new { WeekDay = grouped.Key, Days = grouped };
    
    foreach (var g in datesgrouped)
    {
        Console.Write (String.Format("{0} : {1}", g.WeekDay,g.Days.Count());
    }
