    filterContext.Result = new ViewResult
    {
        ViewName = "Error",
        ViewData = new ViewDataDictionary()
        {
            {"exception", filterContext.Exception}
        }
    };
