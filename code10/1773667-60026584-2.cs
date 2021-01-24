    public void ConfigureServices(IServiceCollection services)
        {
            services.ValidateJwtToken();
            services.AddAuthorization(Options => {
                Options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
--
