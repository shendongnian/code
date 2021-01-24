    var result = tableTotalHours.Select(x=> new 
    									{
    										Date=x.Date,
    										TotalHours=x.TotalHours,
    										CalculatedPrice = tablePricePerHours.Where(c=> (x.Date - c.Date).Ticks>0)
    																			.OrderBy(c=> (x.Date - c.Date).Ticks)
    																			.First()
    																			.Price * x.TotalHours
    									});
