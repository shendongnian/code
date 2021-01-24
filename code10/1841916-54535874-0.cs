public class SessionExpireAttribute : ActionFilterAttribute
{
	public override void OnActionExecuting(ActionExecutingContext actionContext)
	{
		// Adjust this if statement so it's executed hit if your special authentication has *failed*
		if (true)
		{
			actionContext.Result = new HttpUnauthorizedResult("You don't have access to this resource.");
		}
		
		base.OnActionExecuting(actionContext);
	}
}
If you don't do anything in the handler, the controller action will execute as normal.
