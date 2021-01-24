    public static class ProductQueryExtensions
    {
    	public static List<Product> CleanSelect(this IQueryable<Product> q)
    	{
    		return q.Select(p => new Product 
    		{ 
    			Id = p.Id,
    			Description = p.Description.Replace("\r\n", "\n")
    		}).ToList();
    	}
    	
    	public static Product CleanFirstOrDefault(this IQueryable<Product> q)
    	{
    		return q.CleanSelect().FirstOrDefault();
    	}
    }
