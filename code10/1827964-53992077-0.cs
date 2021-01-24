    var result = data
                .GroupBy(d => new
                {
                    d.Type,
                    d.CreatedDate.Year,
                    d.CreatedDate.Month
                })
                .Select(i => new
                {
                    Month = new DateTime(i.Key.Year, i.Key.Month, 1),
                    i.Key.Type,
                    Count = i.Count()
                })
                .ToList();
    			
    		
    		var dateList = result.Select(x=>x.Month).Distinct().ToList();
    		void GenerateEmptyEntries()
    		{
    			foreach(var date in dateList)
    			{
    				foreach(var type in types)
    				{
    					if(!result.Any(x=>x.Month == date && x.Type == type))
    					{
    						result.Add(new {Month = date, Type = type, Count = 0});
    					}
    				}
    			}
    		}
    		
    		GenerateEmptyEntries();
            foreach (var r in result.OrderBy(o=>o.Month)
                .ThenBy(o=>o.Type))
            {
                Console.WriteLine("{0} - {1}: {2}", r.Month, r.Type, r.Count);
            }
