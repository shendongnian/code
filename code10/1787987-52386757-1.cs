	public void ConfigureServices(IServiceCollection services)
	{
		var connectionString = Configuration.GetValue<string>("ConnectionString");
		services.AddDbContext<DbContext>(options => options.UseSqlServer(connectionString);
	}
