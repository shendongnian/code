    public class AppDbContext : DbContext
    {
    	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    	{
    	}
    }
    
    public class AppDbContextProvider : IDisposable
    {
    	//enforcing 1 DbContext per request
    	private Dictionary<string, AppDbContext> _contexts = new Dictionary<string, AppDbContext>();
    
    	public AppDbContext GetDbContext(string dbName)
    	{
    		if (dbName == null)
    			return null;
    		if (_contexts.TryGetValue(dbName, out AppDbContext ctx))
    			return ctx;
    
    		var conStr = GetConnectionString(dbName);
    		if (conStr == null)
    			return null;
    
    		var dbOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    		dbOptionsBuilder.UseSqlServer(conStr);
    		ctx = new AppDbContext(dbOptionsBuilder.Options);
    		_contexts[dbName] = ctx;
    		return ctx;
    	}
    
    	//Any connection string selection logic, either hard-coded or configurable somewhere (e.g. Options).
    	private string GetConnectionString(string dbName)
    	{
    		switch (dbName)
    		{
    			case "A":
    				return "a";
    
    			case "B":
    				return "b";
    
    			default:
    				return null;
    		}
    	}
    
    	//ensure clean dispose after DI scope lifetime
    	public void Dispose()
    	{
    		if (_contexts.Count > 0)
    		{
    			foreach (var ctx in _contexts.Values)
    				ctx.Dispose();
    		}
    	}
    }
    
    public class PopulateDbContextFilter : ActionFilterAttribute
    {
    	public override void OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		var dbName = filterContext.HttpContext.Request.Query["db"];
    		var provider = filterContext.HttpContext.RequestServices.GetRequiredService<AppDbContextProvider>();
    		var ctx= provider.GetDbContext(dbName);
    		if (ctx == null)
    		{
    			filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Error" }));
    		}else
    		{
    			//could also be stored to any other accessible location (e.g. an controller property)
    			filterContext.HttpContext.Items["dbContext"] = ctx;
    		}
    		base.OnActionExecuting(filterContext);
    	}
    }
