    public override void OnAuthorization(AuthorizationContext filterContext)
		{
			base.OnAuthorization(filterContext);
			if (!_isAuthorized)
			{
				filterContext.Result = new HttpUnauthorizedResult();
			}
			else if (filterContext.HttpContext.User.IsInRole("Administrator") || filterContext.HttpContext.User.IsInRole("User") ||  filterContext.HttpContext.User.IsInRole("Manager"))
			{
				// is authenticated and is in one of the roles 
				SetCachePolicy(filterContext);
			}
			else
			{
				filterContext.Controller.TempData.Add("RedirectReason", "You are not authorized to access this page.");
				filterContext.Result = new RedirectResult("~/Error");
			}
		}
