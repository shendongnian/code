    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> where1, 
         Expression<Func<T, bool>> where2)
	{
		InvocationExpression invocationExpression = Expression.Invoke(where2, 
             where1.Parameters.Cast<Expression>());
		return Expression.Lambda<Func<T, bool>>(Expression.OrElse(where1.Body, 
             invocationExpression), where1.Parameters);
	}
	public static IQueryable<ProductDTO> FilterAgeByGroup(IQueryable<ProductDTO> query,  
       List<string> filters, int currentYear)
	{
		var values = new HashSet<int>();
		//Default value
		Expression<Func<ProductDTO, bool>> predicate = (ProductDTO) => false;
		foreach (var key in filters)
		{
			var matchingValue = Items.TryGetValue(key, out int value);
			if (matchingValue)
			{
				values.Add(value);
			}
		}
        if (values.Count == 0)
            return query;
		if (values.Contains(1))
		{
			predicate = predicate.Or(x => x.YearManufactured >= currentYear - 10);
		}
		if (values.Contains(2))
		{
			predicate = predicate.Or(x => x.YearManufactured <= currentYear - 10 && 
                x.YearManufactured >= currentYear - 20);
		}
		if (values.Contains(3))
		{
			predicate = predicate.Or(x => x.YearManufactured <= currentYear - 20 && 
                x.YearManufactured >= currentYear - 70);
		}
		if (values.Contains(4))
		{
			predicate = predicate.Or(x => x.YearManufactured <= currentYear - 70);
		}
		return query.Where(predicate);
	}
