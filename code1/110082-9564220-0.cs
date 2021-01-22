    public partial class SearchManager
    {       
        #region Query
        // A private class for lazy loading static compiled queries.
        private static partial class Query
        {
            internal static readonly Func<MyDataContext,IOrderedQueryable<Search>> GetAll 
    		{
    			get {
    				return CompiledQuery.Compile(
    					(MyDataContext db) =>
    						from s in db.Search
    						orderby s.Name
    						select s);
    			}
    		} 
        #endregion
    	
    	public IQueryable<Search> GetAll()
        {
    		Context.ClearCache();
    		Context.LoadOptions = MyOptions;
            return Query.GetAll(Context);
        }
    	
    	public static readonly DataLoadOptions MyOptions = 
    		(new Func<DataLoadOptions>(() => MakeLoadOptions<Search>(x=>x.Rule)))();
    }
    
    public static class Extensions {
    	public static void ClearCache(this DataContext context)
    	{
    		const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    		var method = context.GetType().GetMethod("ClearCache", FLAGS);
    		method.Invoke(context, null);
    	}
    	
    	public static DataLoadOptions MakeLoadOptions<TEntity, TResult>(this Expression<Func<TEntity,TResult>> func) {
        	DataLoadOptions options = new DataLoadOptions();
    		options.LoadWith(func);
    		return options;
    	}
    }
