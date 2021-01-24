    var query = _dataContext.TrendValues
                  .Where(rr =>
                    rr.Trend.CompanyId == companyId 
                    && rr.TrendType == type 
                    && rr.Trend.DateRecorded >= startDate 
                    && rr.Trend.DateRecorded <= endDate)
                  .Select(rr => new 
                  { 
                    TrendYear = rr.Trend.DateRecorded.Year,
                    TrendMonth = rr.Trend.DateRecorded.Month,
                    rr.Value
                  }).ToListAsync();
        
    var data = query.GroupBy(rr => new { rr.TrendYear, rr.TrendMonth })
                .Select(g => new TrendItem() { ItemTitle = $"{g.Key.Year}-{g.Key.Month}", ItemValues = g.ToList().Select(rr => rr.Value).ToList() })
                .ToList();
    return data;
