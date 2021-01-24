    var orderedItems = Enumerable.Range(1,15)
                       .Select(x=> new Order{Date = DateTime.Now.AddDays(x%3)});
    	var indexItems = orderedItems.GroupBy(x=>x.Date)
                       .SelectMany(x=>x.ToList()
                                .Select((c,index)=>new Order{Date= x.Key, Index=index+1}));
