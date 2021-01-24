    public static bool UserHasSpecificClaim(this HtmlHelper h, string claimType, string claimValue)
    {
        // get user claims
        var user = HttpContext.Current.User as System.Security.Claims.ClaimsPrincipal;
        if (user != null)
        {
            // Get the specific claim if any
            return user.Claims.Any(c => c.Type == claimType && c.Value == claimValue);
        }
        return false;
    }
