		public virtual void OnAuthorization(AuthorizationContext filterContext)
		{
			if (AuthorizeCore(filterContext.HttpContext))
			{ 
				HttpCachePolicyBase cachePolicy = filterContext.HttpContext.Response.Cache;
				cachePolicy.SetProxyMaxAge(new TimeSpan(0));
				cachePolicy.AddValidationCallback(CacheValidateHandler, null /* data */);
			}
            // Is user logged in?
			else if(filterContext.HttpContext.User.Identity.IsAuthenticated)
			{
                // Redirect to custom Unauthorized page
				filterContext.Result = new RedirectResult(unauthorizedUrl);
			} 
            else {
                // Handle in the usual way
				HandleUnauthorizedRequest(filterContext);
			}
		}
