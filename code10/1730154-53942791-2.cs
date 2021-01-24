    public void ConfigureServices(IServiceCollection services)
    {
    	// [...]
    
    	services.AddDbContext<SecurityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Security")));
    
    	services.AddIdentity<ApplicationUser, IdentityRole>()
    		.AddEntityFrameworkStores<SecurityDbContext>()
    		.AddDefaultTokenProviders();
    		
    	services.AddScoped<Microsoft.AspNetCore.Identity.IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();
    
    	// [...]
    }
