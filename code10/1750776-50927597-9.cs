    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // The following line configures the Azure AD B2C authentication with API options.
            services.Configure<AzureADB2CWithApiOptions>(options => Configuration.Bind("AzureADB2C", options));
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(AzureADB2CDefaults.AuthenticationScheme)
                .AddAzureADB2C(options => Configuration.Bind("AzureADB2C", options));
            // The following line registers the OpenID Connect authentication options for the Azure AD B2C authentication middleware.
            services.AddSingleton<IConfigureOptions<OpenIdConnectOptions>, AzureADB2COpenIdConnectOptionsConfigurator>();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
    }
