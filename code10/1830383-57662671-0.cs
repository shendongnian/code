public override void OnAuthorization(HttpActionContext actionContext)
{
    if (actionContext == null)
    {
        throw Error.ArgumentNull("actionContext");
    }
    if (SkipAuthorization(actionContext))
    {
        return;
    }
    if (!IsAuthorized(actionContext))
    {
        HandleUnauthorizedRequest(actionContext);
    }
}
