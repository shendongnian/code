    data
    	.Select(i => new
    	{
    		i.Status,
    		i.InvoiceType,
    		LessThan100 = i.InvoicePayments < 100 ? i.EligibleValue : 0,
    		LessThan500 = i.InvoicePayments < 500 ? i.EligibleValue : 0,
    	})
    	.GroupBy(i => new { i.Status, i.InvoiceType })
    	.Select(g => new
    	{
    		g.Key,
    		Count = g.Count(),
    		TotalLessThan100 = g.Sum(i => i.LessThan100),
    		TotalLessThan500 = g.Sum(i => i.LessThan500)
    	});
