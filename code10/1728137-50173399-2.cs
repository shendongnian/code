    // ensure you import the System.Linq.Dynamic namespace
    public IQueryable<FooBar> GetDataQuery(bool includeTitle, bool includeDescription)
    {
        // build a list of columns, at least 1 must be selected, so maybe include an Id
    	var columns = new List<string>(){nameof(FooBar.Id)};        
    	if (includeTitle)
    		columns.Add(nameof(FooBar.Title));
    	if (includeDescription)
    		columns.Add(nameof(FooBar.Description));
        // join said columns
    	var select = $"new({string.Join(", ", columns)})";
    	var query = ctx.FooBars.AsQueryable()
    		.Where(f => f.Id > 240)
    		.Select(select)
    		.OfType<FooBar>();
    	return query;
    }
