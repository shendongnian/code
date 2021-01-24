	if (spec.Order != null)
	{
		var count = spec.Order.Count;
		for (int i = 0; i < count; ++i)
		{
			if (query is IOrderedQueryable<T> orderedQuery)
			{
				query = orderedQuery.ThenBy(spec.Order[i]);
			}
			else
			{
				query = query.OrderBy(spec.Order[i]);
			}
		}
	}
