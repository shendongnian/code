		public virtual void OnAuthorization(AuthorizationContext filterContext)
		{
			if (AuthorizeCore(filterContext.HttpContext))
			{ 
				HttpCachePolicyBase cachePolicy = filterContext.HttpContext.Response.Cache;
				cachePolicy.SetProxyMaxAge(new TimeSpan(0));
				cachePolicy.AddValidationCallback(CacheValidateHandler, null /* data */);
			}
			else if(filterContext.HttpContext.User.Identity.IsAuthenticated)
			{
				HandleUnauthorizedRequest(filterContext);
			}
			else{
				filterContext.Result = new RedirectResult(someurl);
			}
		}
