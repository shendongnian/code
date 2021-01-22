    void Summarize(IEnumerable<Sections> sections)
    {
    	var result = sections.Aggregate(new
    	{
    		DateBegin = DateTime.MaxValue,
    		DateEnd = DateTime.MinValue,
    		Income = 0,
    		Expenditure = 0
    	},
    		(agg, next) =>
    		new
    		{
    			DateBegin = next.Date < agg.DateBegin ? next.Date : agg.DateBegin,
    			DateEnd = next.Date > agg.DateEnd ? next.Date : agg.DateEnd,
    			Income = agg.Income + (next.IsIncome ? next.Amount : 0),
    			Expenditure = agg.Expenditure + (next.IsExpenditureBank ? next.Amount : 0) +
    				(next.IsExpenditureClient ? next.Amount : 0)
    		}
    	);
    }
