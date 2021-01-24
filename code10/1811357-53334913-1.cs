    var query = _dataContext.TrendValues
                 .Where(rr =>
                   rr.Trend.CompanyId == companyId &&
                   rr.TrendType == type &&
                   rr.Trend.DateRecorded >= startDate &&
                   rr.Trend.DateRecorded <= endDate)
                   .Select(rr => new 
                   { 
                     TrendDate = rr.Trend.DateRecorded.Year + "-" + rr.Trend.DateRecorded.Month,
                     rr.Value
                   }).ToListAsync();
        
    var data = query.GroupBy(rr => rr.TrendDate)
                 .Select(g => new TrendItem() { ItemTitle = $"{g.Key}", ItemValues = g.ToList().Select(rr => rr.Value).ToList() })
                 .ToList();
    return data;
