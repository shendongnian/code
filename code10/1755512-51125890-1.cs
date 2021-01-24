	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMvc();
		services.AddHttpContextAccessor(); // does pretty much the same as above
	}
