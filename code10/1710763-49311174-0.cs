    var GroupName = (from p in FilterList
                     where p.GroupName != null
                     group p by new { month = p.ReportedDateTime.Month, year = p.ReportedDateTime.Year, GroupName = p.GroupName.ToLower()  } into d
                     select new {
                         dt = string.Format("{0}/{1}", d.Key.month, d.Key.year),
                             month = d.Key.month,
                             monthName = new DateTime(d.Key.year, d.Key.month, 1).ToString("MMM", CultureInfo.InvariantCulture),
                             count = d.Count(),
                             GroupName = d.First().GroupName
                     }).OrderByDescending(g => g.count)
                       .ThenBy(g => g.GroupName).Take(20);
