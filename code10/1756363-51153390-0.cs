    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        if (httpContext == null)
            throw new ArgumentNullException("httpContext");
        var user = httpContext.User;
        if (!user.Identity.IsAuthenticated)
        {
            return false;
        }
        var userRoles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
        if (_allowedRoles.Length > 0 && !_allowedRoles.Any(x => userRoles.Any(y => x.Equals(y)))))
        {
            return false;
        }
        return true;
    }
