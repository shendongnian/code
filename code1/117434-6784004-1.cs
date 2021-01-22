    /// <summary>
    /// Generates a fully qualified URL to an action method by using
    /// the specified action name, controller name and route values.
    /// </summary>
    /// <param name="url">The URL helper.</param>
    /// <param name="actionName">The name of the action method.</param>
    /// <param name="controllerName">The name of the controller.</param>
    /// <param name="routeValues">The route values.</param>
    /// <returns>The absolute URL.</returns>
    public static string AbsoluteAction(this UrlHelper url,
        string actionName, string controllerName, object routeValues = null)
    {
        return url.Action(actionName, controllerName, routeValues, "http");
    }
