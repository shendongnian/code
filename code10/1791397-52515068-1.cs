    public static bool IsEmpty<T>(this IEnumerable<T> list, IEnumerable<T> treatAsEmpty = null)
	{
		if (treatAsEmpty == null) treatAsEmpty = Enumerable.Empty<T>();
		return list.All(treatAsEmpty.Contains);
	}
