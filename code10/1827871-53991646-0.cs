    public static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider, IHostingEnvironment env)
    {
    	var result = false;
    
    	using (var scope1 = serviceProvider.CreateScope())
    	using (var db1 = scope1.ServiceProvider.GetService<MainContext>())
    	{
    		 result = await db1.Database.EnsureCreatedAsync();
    		if (result)
    		{
    
    			InsertTestData(serviceProvider, env);
    		}
    	}
    }
