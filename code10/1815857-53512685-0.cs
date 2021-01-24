    var six = new DateTime(2018, 10, 01, 6, 0, 0, 0);
    var seven = new DateTime(2018, 10, 01, 7, 0, 0, 0);
    var eight = new DateTime(2018, 10, 01, 8, 0, 0, 0);
    
    var result = forecast
    .GroupBy(_ => new {
    	_.LocationId,
    	StartTime = _.EndTime > six &&
    				_.EndTime <= seven ? six : seven,
    	EndTime =   _.EndTime > six &&
    			    _.EndTime <= seven ? seven : eight
    })
    .Select(x => new {
    	x.Key.LocationId,
    	x.Key.StartTime,
    	x.Key.EndTime,
    	CountOfEmployees = x.Sum(y=>y.CountOfEmployees)});
