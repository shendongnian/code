    public static async Task<IActionResult>  Run(HttpRequest req, ILogger log, ClaimsPrincipal principal)
    {
        log.LogInformation("C# HTTP trigger function processed a request."); 
        var isAuthenticated = principal.Identity.IsAuthenticated; 
        var idName = string.IsNullOrEmpty(principal.Identity.Name) ? "null" : principal.Identity.Name;
        log.LogInformation($"principal.Identity.IsAuthenticated = '{isAuthenticated}' and principal.Identity.Name = '{idName}'");
        var owner = (principal.FindFirst(ClaimTypes.NameIdentifier))?.Value;
        
        return new OkObjectResult($"principal.Identity.IsAuthenticated = '{isAuthenticated}' and principal.Identity.Name = '{idName}'");
        
    }
    private static string GetIdentityString(ClaimsIdentity identity)
    {
        var userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim != null)
        {
            // user identity
            var userNameClaim = identity.FindFirst(ClaimTypes.Name);
            return $"Identity: ({identity.AuthenticationType}, {userNameClaim?.Value}, {userIdClaim?.Value})";
        }
        else
        {
            // key based identity
            var authLevelClaim = identity.FindFirst("http://schemas.microsoft.com/2017/07/functions/claims/authlevel");
            var keyIdClaim = identity.FindFirst("http://schemas.microsoft.com/2017/07/functions/claims/keyid");
            return $"Identity: ({identity.AuthenticationType}, {authLevelClaim?.Value}, {keyIdClaim?.Value})";
        }
    }
