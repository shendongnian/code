	public static IList<T> CreateReportObject<T>(IList<T> items, ISearchOptions searchOptions) where T : new()
	{
		Type sortFieldType = typeof(T).GetProperty(searchOptions.SortField).PropertyType;
		MethodInfo createMethod = typeof(TableGenerationHelper).GetMethod("CreateSortedList");
		MethodInfo methodRef = createMethod?.MakeGenericMethod(typeof(T), sortFieldType);
		Object[] args = { items, searchOptions.SortField, searchOptions.SortDirection };
		var results = (IList<T>)methodRef?.Invoke(null, args);
		return results;
	}
	public static IList<T> CreateSortedList<T, TH>(IList<T> items, String sortField, String sortDirection) where T : new()
	{
		Type type = typeof(T);
		PropertyInfo propInfo = type.GetProperty(sortField);
		Func<T, TH> orderByFunc = x =>
		{
			return (TH)propInfo.GetValue(x, null);
		};
		return LoadListOrderedByDirection(items, orderByFunc, sortDirection);
	}
