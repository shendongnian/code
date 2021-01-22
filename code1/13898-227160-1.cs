    public partial class Repository
    {
    	partial void ProvideDefaultSorting(ref IOrderedQueryable<Category> currentQuery);
    
    	public IQueryable<Category> List(int startIndex, int count)
    	{
    		NorthwindEntities ent = new NorthwindEntities();
    		IOrderedQueryable<Category> query = ent.CategorySet;
    		var oldQuery = query;
    		ProvideDefaultSorting(ref query);
    		if (oldQuery.Equals(query)) // the partial method did nothing with the query, or just didn't exist
    		{
    			query = query.OrderBy(c => c.CategoryID);
    		}
    		return query.Skip(startIndex).Take(count);
    	}
    	// the rest..        
    }
    
    public partial class Repository
    {
    	partial void ProvideDefaultSorting(ref IOrderedQueryable<Category> currentQuery)
    	{
    		currentQuery = currentQuery.Where(c => c.CategoryName.Contains(" ")).OrderBy(c => c.CategoryName); // compile time forced sotring
    	}
    }
