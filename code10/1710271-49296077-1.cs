    var result = dbQuery
    	.AsEnumerable()
    	.Select(r =>
    	{
    		r.Group.RetailStores = r.Stores.ToList();
    		return r.Group;
    	})
    	.ToList();
