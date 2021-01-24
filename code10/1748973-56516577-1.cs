    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IUserStore<IdentityUser>, CustomUserStore>();
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
        services.AddDefaultIdentity<IdentityUser>()
            .AddDefaultUI(UIFramework.Bootstrap4)
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }
