    /// <summary>
    /// Checks the current action via RouteData
    /// </summary>
    /// <param name="helper">The HtmlHelper object to extend</param>
    /// <param name="actionName">The Action</param>
    /// <param name="controllerName">The Controller</param>
    /// <returns>Boolean</returns>
    public static bool IsCurrentAction(this HtmlHelper helper, string actionName, string controllerName)
    {
        string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
        string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];
                
        if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
            return true;
    
        return false;
    }
