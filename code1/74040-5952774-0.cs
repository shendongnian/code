    protected void Application_Error()
		{			
			if (HttpContext.Current.Request.IsAjaxRequest())
			{
				HttpContext ctx = HttpContext.Current;
				ctx.Response.Clear();
				RequestContext rc = ((MvcHandler)ctx.CurrentHandler).RequestContext;
				rc.RouteData.Values["action"] = "AjaxGlobalError";
				// TODO: distinguish between 404 and other errors if needed
				rc.RouteData.Values["newActionName"] = "WrongRequest";
				rc.RouteData.Values["controller"] = "ErrorPages";
				IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
				IController controller = factory.CreateController(rc, "ErrorPages");
				controller.Execute(rc);
				ctx.Server.ClearError();
			}
		}
