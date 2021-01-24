    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // …
        context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
    }
