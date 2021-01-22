	public static class EnumerableXtensions
	{
		public static IEnumerable<TModel> SelectWithIndex<TModel>(
            this IEnumerable<TModel> collection) where TModel : class, IIndexable
		{
			return collection.Select((item, index) =>
			{
				item.Index = index;
				return item;
			});
		}
	}
    public class SomeModelDTO : IIndexable
    {
    	public Guid Id { get; set; }
    	public string Name { get; set; }
    	public decimal Price { get; set; }
    	
    	public int Index { get; set; }
    }
    
    // In a method
    var items = from a in db.SomeTable
    		    where a.Id == someValue
    		    select new SomeModelDTO
    		    {
    			    Id = a.Id,
    			    Name = a.Name,
    			    Price = a.Price
    		    };
    				  
    return items.SelectWithIndex()
			    .OrderBy(m => m.Name)
 			    .Skip(pageStart)
			    .Take(pageSize)
			    .ToList();
