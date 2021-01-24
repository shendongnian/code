    var result = forecast.GroupBy(x=>new {x.StartTime.Hour, x.LocationId, x.DepartmentId})
    					.Select(x=> new Forecast
    								{ 
    									LocationId = x.Key.LocationId, 
    									DepartmentId = x.Key.DepartmentId, 
                                        StartTime =  x.ToList().OrderBy(e=>e.StartTime).First().StartTime,
    									EndTime =  x.ToList().OrderBy(e=>e.EndTime).Last().EndTime,
    									CountOfEmployees = x.ToList().Sum(c=>c.CountOfEmployees) 
    									});
