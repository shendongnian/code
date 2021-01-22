    public static class CustomerExtension
    {
    	public static void AttachWhereClauses(this IEnumerable<Customer> customers, IEnumerable<Func<Customer, bool>> whereClauses)
    	{
    		foreach (var whereClause in whereClauses)
    		{
    			customers.Where(whereClause);
    		}
    	}
    }
