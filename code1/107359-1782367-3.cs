    public static class IEnumerableExtension
    {
    	public static void AttachWhereClauses<T>(this IEnumerable<T> source, IEnumerable<Func<T, bool>> whereClauses)
    	{
    		foreach (var whereClause in whereClauses)
    		{
    			source.Where(whereClause);
    		}
    	}
    }
    var listedCustomers = customers.AttachWhereClauses(whereClauses).ToList();
