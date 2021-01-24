	if (spec.Order != null)
	{
		var count = spec.Order.Count;
        IOrderedQueryable<T> orderedQuery = null;
        for (int i = 0; i < count; ++i)
        {
            if (i == 0)
            {
                orderedQuery = query.OrderBy(spec.Order[i]);
            }
            else
            {
                orderedQuery = orderedQuery.ThenBy(spec.Order[i]);
            }
        }
        query = orderedQuery ?? query;
	}
