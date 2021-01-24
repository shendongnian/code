    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContextPool<CcrDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDbConnection")));
        services
            .AddIdentity<CcrUser, CcrRole>(t =>
            {
                t.User.RequireUniqueEmail = true;
            })
            .AddRoleValidator<RoleValidator<CcrRole>>()
            .AddRoleManager<RoleManager<CcrRole>>()
            .AddRoleStore<RoleStore<CcrRole, CcrDbContext, int>>()
            .AddUserStore<UserStore<CcrUser, CcrRole, CcrDbContext, int>>()
            .AddDefaultTokenProviders();
    }
