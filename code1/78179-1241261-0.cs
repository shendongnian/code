	public static IQueryable<Rates> ProcessRates(this IEnumerable<Rates> rates)
	{
		foreach (Rates r in rates)
			r.Process();
		return rates.AsQueryable();
	}
