    var WeekCountQuery = from c in whereClause
                         group c by 
                         //make sure you have the extension method
                         c.LogDate.GetIso8601WeekOfYear() 
                         into grp
                         select new
                         {
                              Week = grp.Key,
                              Clicks = grp.Count(),
                         };
