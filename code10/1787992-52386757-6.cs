	public void ConfigureServices(IServiceCollection services)
	{
		var connectionString = Configuration.GetConnectionString("Default");
		services.AddDbContext<DbContext>(options => options.UseSqlServer(connectionString);
	}
