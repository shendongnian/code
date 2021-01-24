	public void ConfigureServices(IServiceCollection services)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
		services.AddMvc();
		services.AddMemoryCache();
		services.AddSingleton<LinkCachedRouteDataProvider>();
	}
