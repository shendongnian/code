    var query = _context
    	.Organization
    	.SelectMany(organization => organization.Invoices, (organization, invoice) => new
    	{
    		organization.Id,
    		organization.Number,
    		organization.Name,
    		invoice.Date
    	})
    	.GroupBy(e => new
    	{
    		e.Number,
    		e.Name
    	})
    	.Select(g => new
    	{
    		Id = g.Min(e => e.Id),
    		Name = g.Key.Name,
    		Number = g.Key.Number,
    		First = g.Min(e => e.Date),
    		Last = g.Max(e => e.Date),
    	})
    	.OrderBy(e => e.Name);
