    var result = forecast.Select(s => 
        new Forecast()
        {
            StartTime = s.StartTime.Date.AddHours(s.StartTime.Hour),
            EndTime = s.EndTime.Date.AddHours(s.EndTime.Hour),
            CountOfEmployees = s.CountOfEmployees,
            DepartmentId = s.DepartmentId,
            LocationId = s.LocationId
        }
    )
    .GroupBy(g => new { g.StartTime, g.LocationId, g.DepartmentId })
    .Select(s => 
        new Forecast()
        {
            LocationId = s.Key.LocationId,
            DepartmentId = s.Key.DepartmentId,
            StartTime = s.Key.StartTime,
            EndTime = s.Max(m => m.EndTime),
            CountOfEmployees = s.Sum(c => c.CountOfEmployees),
        }
    )
    .OrderBy(o => o.LocationId)
    .ThenBy(o => o.DepartmentId)
    .ThenBy(o => o.StartTime)
    .ToList();
