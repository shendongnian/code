    protected virtual bool IsAuthorized(HttpActionContext actionContext)
            {
                if (actionContext == null)
                {
                    throw Error.ArgumentNull("actionContext");
                }
    
                IPrincipal user = actionContext.ControllerContext.RequestContext.Principal;
                if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
                {
                    return false;
                }
    
                if (_usersSplit.Length > 0 && !_usersSplit.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
                {
                    return false;
                }
    
                if (_rolesSplit.Length > 0 && !_rolesSplit.Any(user.IsInRole))
                {
                    return false;
                }
    
                return true;
            }
