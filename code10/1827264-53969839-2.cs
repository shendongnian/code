    var result = Enumerable.Range(0,24).Select(x=> 
    						new DateRange{ 
    							Begin = new DateTime(today.Year,today.Month,today.Day,x,0,0),
    							End = new DateTime(today.Year,today.Month,today.Day,x,59,59)
    							}).Where(x=> !excludeList.Select(c=>c.Begin).ToList().Contains(x.Begin)
    										&& !excludeList.Select(c=>c.End).ToList().Contains(x.End));
