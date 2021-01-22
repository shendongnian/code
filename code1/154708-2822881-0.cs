	public class EntityAuthRequired : FilterAttribute, IAuthorizationFilter 
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			var entityCode = filterContext.RouteData.Values["entityCode"] as string;
			// do your logic...			
			if (!allowed)
				filterContext.Result = new HttpUnauthorizedResult();			
		}
	}
