    var query = myList
    		.GroupBy(c => c.Name)
    		.Select(g => new {
    			Name = g.Key,
    			_2018_11_01 = g.Where(c => c.Date == new DateTime(2018, 11, 1)).Max(c => c.Hour),
    			_2018_11_02 = g.Where(c => c.Date == new DateTime(2018, 11, 2)).Max(c => c.Hour)
    		});
