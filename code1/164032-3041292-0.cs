    protected internal RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> action) where TController: Controller
    {
        var controllerName = typeof(TController).Name.Replace("Controller", string.Empty);
        var actionName = ((MethodCallExpression)action.Body).Method.Name;
        return RedirectToAction(actionName, controllerName);
    }
