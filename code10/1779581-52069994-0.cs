    var AssignerDaysCount = assignerList.Where(filter => 
    totalDaysInDateRange.Contains(filter.Date.Date))
    .GroupBy(item => item.AssignerName)
    .Select(lst => new { AssignerName = lst.Key, DaysCount = lst.Select(cnt   =>   cnt.Date).Distinct().Count() })
    .ToList();
