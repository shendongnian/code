    public static string RenderViewToString(ControllerContext context, string viewPath, object viewModel = null, bool partial = false)
    {
    	// get the ViewEngine for this view
    	ViewEngineResult viewEngineResult = null;
    	if (partial)
    		viewEngineResult = ViewEngines.Engines.FindPartialView(context, viewPath);
    	else
    		viewEngineResult = ViewEngines.Engines.FindView(context, viewPath, null);
    
    	if (viewEngineResult == null)
    		throw new FileNotFoundException("View cannot be found.");
    
    	// get the view and attach the model to view data
    	var view = viewEngineResult.View;
    	context.Controller.ViewData.Model = viewModel;
    
    	string result = null;
    
    	using (var sw = new StringWriter())
    	{
    		var ctx = new ViewContext(context, view, context.Controller.ViewData, context.Controller.TempData, sw);
    		view.Render(ctx, sw);
    		result = sw.ToString();
    	}
    
    	return result;
    }
