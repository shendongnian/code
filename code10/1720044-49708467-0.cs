    public class CheckModelStateAttribute : ActionFilterAttribute
    {
    	public override void OnActionExecuting(ActionExecutingContext context)
    	{
    		if (!context.ModelState.IsValid)
    		{
    			context.Result = new BadRequestObjectResult(context.ModelState);
    		}
    	}
    }
