    public static IEnumerable<T> SelectByParameterList<T, PropertyType>(this Table<T> items, IEnumerable<PropertyType> parameterList, Expression<Func<T, PropertyType>> propertySelector, int blockSize) where T : class
    {
    	var groups = parameterList
    		.Select((Parameter, index) =>
    			new
    			{
    				GroupID = index / blockSize, //# of parameters per request
    				Parameter
    			}
    		)
    		.GroupBy(x => x.GroupID)
    		.AsEnumerable();
    	
    	var selector = LinqKit.Linq.Expr(propertySelector);
    	
    	var results = groups
    	.Select(g => new { Group = g, Parameters = g.Select(x => x.Parameter) } )
    	.SelectMany(g => 
    		/* AsExpandable() extension method requires LinqKit DLL */
    		items.AsExpandable().Where(item => g.Parameters.Contains(selector.Invoke(item)))
    	);
    
    	return results;
    }
