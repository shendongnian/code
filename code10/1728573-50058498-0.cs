    public void OnAuthorization(AuthorizationContext filterContext)
    {
	 if (filterContext != null)
	  {
		BaseController baseController = (BaseController)filterContext.Controller;
		string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
		if (!baseController.SessionStore.ItemExists(SessionKeys.CEHCKSESSIONEXIST))
		{
			if (baseController.Request.IsAjaxRequest())
			{
				filterContext.Result = new JsonResult
				{
					Data = new { Status = CommonConstants.SessionTimeout },
					JsonRequestBehavior = JsonRequestBehavior.AllowGet,
				};
			}
			else
			{
				filterContext.Result = new RedirectToRouteResult(
						new RouteValueDictionary {
				{ "Controller", "Integration" },
				{ "Action", "SessionExpired" }
			 });
			}
		}
	 }
    }
