    protected void Application_Error()
    {
        var exception = Server.GetLastError();
        // TODO do whatever you want with exception, such as logging, set errorMessage, etc.
		var errorMessage = "SOME FRIENDLY MESSAGE";
		        
		// TODO: UPDATE BELOW FOUR PARAMETERS ACCORDING TO YOUR ERROR HANDLING ACTION
		var errorArea = "AREA";
		var errorController = "CONTROLLER";
		var errorAction = "ACTION";
		var pathToViewFile = $"~/Areas/{errorArea}/Views/{errorController}/{errorAction}.cshtml"; // THIS SHOULD BE THE PATH IN FILESYSTEM RELATIVE TO WHERE YOUR CSPROJ FILE IS!
        var requestControllerName = Convert.ToString(HttpContext.Current.Request.RequestContext?.RouteData?.Values["controller"]);
        var requestActionName = Convert.ToString(HttpContext.Current.Request.RequestContext?.RouteData?.Values["action"]);
		
		var controller = new BaseController(); // REPLACE THIS WITH YOUR BASE CONTROLLER CLASS
		var routeData = new RouteData { DataTokens = { { "area", errorArea } }, Values = { { "controller", errorController }, {"action", errorAction} } };
		var controllerContext = new ControllerContext(new HttpContextWrapper(HttpContext.Current), routeData, controller);
		controller.ControllerContext = controllerContext;
		
		var sw = new StringWriter();
		var razorView = new RazorView(controller.ControllerContext, pathToViewFile, "", false, null);
		var model = new ViewDataDictionary(new HandleErrorInfo(exception, requestControllerName, requestActionName));
		var viewContext = new ViewContext(controller.ControllerContext, razorView, model, new TempDataDictionary(), sw);
		viewContext.ViewBag.ErrorMessage = errorMessage;
		//TODO: add to ViewBag what you need
		razorView.Render(viewContext, sw);
		HttpContext.Current.Response.Write(sw);
        Server.ClearError();
        HttpContext.Current.Response.End(); // No more processing needed (ex: by default controller/action routing), flush the response out and raise EndRequest event.
    }
