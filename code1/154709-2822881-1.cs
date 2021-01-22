	public class EntityAuthRequired : FilterAttribute, IAuthorizationFilter 
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			//Make sure that this is not NULL before assigning value as string...
			var entityCode = filterContext.RouteData.Values["entityCode"] as string;
			// do your logic...			
			if (!allowed)
				filterContext.Result = new HttpUnauthorizedResult();			
		}
	}
