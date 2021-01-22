    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        
        TestViewModel viewModel = new TestViewModel; 
        
        //Here set all the properties of your viewModel such as your exception message
        
        filterContext.Controller.ViewData.Model = viewModel;
        filterContext.Result = new ViewResult { ViewName = "Login", ViewData = new ViewDataDictionary(viewModel)};
        filterContext.ExceptionHandled = true;
        
    }
