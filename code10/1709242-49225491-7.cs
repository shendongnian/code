    public static void RegisterContext(IServiceCollection services, string connectionString, IHostingEnvironment hostingEnvironment)
    {
    	if (connectionString == null)
    		throw new ArgumentNullException(nameof(connectionString));
    	if (services == null)
    		throw new ArgumentNullException(nameof(services));
    
    	services.AddDbContext<MyContext>(options =>
    	{
    		if (hostingEnvironment == null || hostingEnvironment.IsTesting())
    		{
    			var connection = new SqliteConnection("DataSource='file::memory:?cache=shared'");
    			connection.Open();
    			options.UseSqlite(connection);
    			options.UseLoggerFactory(MyLoggerFactory);
    		}
    		else
    		{
    			options.UseSqlServer(connectionString);
    			options.UseLoggerFactory(MyLoggerFactory);
    		}
    	});
    
    	if (hostingEnvironment == null || hostingEnvironment.IsTesting())
    	{
    		services.AddSingleton<IMyContext>(service =>
    		{
    			var context = service.GetService<MyContext>();
    			context.Database.EnsureCreated();
    			return context;
    		});
    	} else {
    		services.AddTransient<IMyContext>(service => service.GetService<MyContext>());
    	}
     }
