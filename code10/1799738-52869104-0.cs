    public class ConflictsFilter : ActionFilterAttribute
    {
    	const string CONFLICT_KEY_NAME = "conflict-checker";
    	static readonly TimeSpan EXPIRE_AFTER = TimeSpan.FromMinutes(30);
    
    	private static bool ShouldCheck(ActionDescriptor actionDescription, IQueryCollection queries)
    	{
    		return queries.ContainsKey(CONFLICT_KEY_NAME);
    	}
    
    	private string BuildKey(string uid, string requestId)
    	{
    		return $"{uid}_{requestId}";
    	}
    
    	public override void OnActionExecuting(ActionExecutingContext context)
    	{
    		if (ShouldCheck(context.ActionDescriptor, context.HttpContext.Request.Query))
    		{
    			using (var client = RedisConnectionPool.ConnectionPool.GetClient())
    			{
    				string key = BuildKey(context.HttpContext.User.GetId(), context.HttpContext.Request.Query[CONFLICT_KEY_NAME]);
    				string existing = client.Get<string>(key);
    				if (existing != null)
    				{
    					var conflict = new ContentResult();
    					conflict.Content = existing;
    					conflict.ContentType = "application/json";
    					conflict.StatusCode = 409;
    
    					context.Result = conflict;
    					return;
    				}
    				else
    				{
    					client.Set(key, string.Empty, EXPIRE_AFTER);
    				}
    			}
    		}
    
    		base.OnActionExecuting(context);
    	}
    
    	public override void OnResultExecuted(ResultExecutedContext context)
    	{
    		base.OnResultExecuted(context);
    		if (ShouldCheck(context.ActionDescriptor, context.HttpContext.Request.Query) && context.HttpContext.Response.StatusCode == 200)
    		{
    			string key = BuildKey(context.HttpContext.User.GetId(), context.HttpContext.Request.Query[CONFLICT_KEY_NAME]);
    			using (var client = RedisConnectionPool.ConnectionPool.GetClient())
    			{
    				var responseBody = string.Empty;
    				if (context.Result is ObjectResult)
    				{
    					ObjectResult result = context.Result as ObjectResult;
    					responseBody = JsonConvert.SerializeObject(result.Value);
    				}
    
    				if (responseBody != string.Empty)
    					client.Set(key, responseBody, EXPIRE_AFTER);
    			}
    		}
    	}
    }
