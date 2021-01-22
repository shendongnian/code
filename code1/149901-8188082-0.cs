    class MembershipTriggerLastActivityDate : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.HttpContext.User.Identity.IsAuthenticated)
			{
				MembershipUser user = Membership.GetUser(filterContext.HttpContext.User.Identity.Name, true);
			}	
			base.OnActionExecuting(filterContext);
		}
	}
