	public void ConfigureServices(IServiceCollection services)
	{
		services.AddDbContext<MyDbContext>(options =>... your options here); // register your context
		services.AddSingleton<SmsService, SmsService>(); // register your sms servcice which is required data context
		services.AddSingleton<DataParser, DataParser>(); // register your parser
	}
