    <pre><code>public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
            {
                new ApiResource
                {
                    Name= "portal",
                    UserClaims = { "tenantId","userId","user" }, 
                    Scopes =
                    {
                        new Scope("portal","portal")
                    }
                },
    
            };
        }
