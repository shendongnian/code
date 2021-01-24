    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        // Check if the CheckSession attribute is present and skip the session 
        // check if [CheckSession(false)] was explicitly provided.
        bool checkSession = filterContext.ActionDescriptor.GetCustomAttributes(typeof(CheckSession), true)
            .OfType<CheckSession>()
            .Select(attr => attr.Enabled)
            .DefaultIfEmpty(true)
            .First();
        if (checkSession) 
        {
            // Check session
        }
    }
