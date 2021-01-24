    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
        services.AddJwt(Configuration);
        services
            .AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
        ....
    }
