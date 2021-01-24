    data
    	.GroupBy(i => new { i.Status, i.InvoiceType })
    	.Select(g => new
    	{
    		g.Key,
    		Count = g.Count(),
    		TotalLessThan100 = g.Sum(i => i.InvoicePayments < 100 ? i.EligibleValue : 0),
    		TotalLessThan500 = g.Sum(i => i.InvoicePayments < 500 ? i.EligibleValue : 0)
    	});
