    public class ResponseCodeAttribute : Attribute, IResultFilter
    {
    	private readonly int _statusCode;
    	public ResponseCode(int statusCode)
    	{
    		this._statusCode = statusCode;
    	}
    
    	public void OnResultExecuting(ResultExecutingContext context)
    	{
    	}
    	public void OnResultExecuted(ResultExecutedContext context)
    	{
    		context.HttpContext.Response.StatusCode = _statusCode;
    	}
    }
