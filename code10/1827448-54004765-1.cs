    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new ApiResource("api1", "My API"),
            new ApiResource("roles", "My Roles", new[] { "role" })
        };
    }
