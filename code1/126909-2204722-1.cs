    public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
    {
        //you might have to customize this bit
        if (controllerContext.HttpContext.Request.IsAjaxRequest())
            return base.FindView(controllerContext, viewName, "Modal", useCache);
        return base.FindView(controllerContext, viewName, "Site", useCache);
    }
