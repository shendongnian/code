    public partial class Repository
    {
    	partial void ProvideDefaultSorting(ref IOrderedQueryable<Category> currentQuery);
    
    	public IQueryable<Category> List(int startIndex, int count)
    	{
    		NorthwindEntities ent = new NorthwindEntities();
    		IOrderedQueryable<Category> query = ent.CategorySet;
    		ProvideDefaultSorting(ref query);
    		if (!PartialMethodHasNotRun)
    		{
    			query = query.OrderBy(c => c.CategoryID);
    		}
    		return query.Skip(startIndex).Take(count);
    	}
    	public IQueryable<Category> List(string sortExpression, int startIndex, int count)
    	{
    		return List(sortExpression).Skip(startIndex).Take(count);
    	}
    	public IQueryable<Category> List(string sortExpression)
    	{
    		return AddSortingToTheExpressionTree(List(), sortExpression);
    	}
    	public IQueryable<Category> List()
    	{
    		NorthwindEntities ent = new NorthwindEntities();
    		return ent.CategorySet;
    	}
    
    	private Boolean IsSorted(IQueryable<Category> query)
    	{
    		return query is IOrderedQueryable<Category>;
    	}
    }
    
    public partial class Repository
    {
    	partial void ProvideDefaultSorting(ref IOrderedQueryable<Category> currentQuery)
    	{
    		currentQuery = currentQuery.Where(c => c.CategoryName.Contains(" ")).OrderBy(c => c.CategoryName); // no sorting..
    	}
    }
