    private static void OnPreRequestHandlerExecute(object sender, EventArgs e)
    {
    	var handler = HttpContext.Current.Handler;
    	HttpContext.Current.Application.GetContainer().BuildUp(handler.GetType(), handler);
    
    	// User Controls are ready to be built up after the page initialization is complete
    	var page = HttpContext.Current.Handler as Page;
    	if (page != null)
    	{
    		page.InitComplete += OnPageInitComplete;
    	}
    }
