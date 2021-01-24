    //Config.cs
    public static IEnumerable<ApiResource> GetApiResources()
    {
        ApiResource apiResource = new ApiResource("api1", "DG Analytics Portal API")
        {
            UserClaims =
            {
                JwtClaimTypes.Name,
                JwtClaimTypes.Email,
                AnalyticsConstants.TenantRoleClaim // my custom claim key/name
            }
        };
    
        return new List<ApiResource>
        {
            apiResource
        };
    }
