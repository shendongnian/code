    protected void DoActionExecuted<T>(ActionExecutedContext filterContext)
    {
        var result = (ViewResult) filterContext.Result;
        var list = (IQueryable<T>) result.ViewData.Model;
        result.ViewData.Model = list.Skip((Page - 1)*PageSize)
                                    .Take(PageSize)
                                    .ToList();
    }
