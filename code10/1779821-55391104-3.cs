    public bool ValidateTokenClaimsPermissionExists(string token, string domain, string audience, string permission)
    {
        var claimsPrincipal = GetValidatedToken(token, _tokenValidationParameters);
    
        var scopePermission = claimsPrincipal.FindFirst(c => c.Type == Constants.PermissionsClaimTypeName && c.Value == permission);
        return scopePermission != null;
    }
