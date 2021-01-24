    public void ConfigureServices(IServiceCollection services)
    {
       services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
       services.AddTransient<IClaimsTransformation, ClaimsTransformer>();
       ...
    
       services.AddAuthorization(options =>
            {
                options.AddPolicy("MasterAdminsOnly", policy => policy.RequireClaim(ClaimTypes.Role, "MasterAdmin"));
                options.AddPolicy("AdminsOnly", policy => policy.RequireClaim(ClaimTypes.Role, "MasterAdmin", "DeptAdmin"));
            });
    }
