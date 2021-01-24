    public void ConfigureServices(IServiceCollection services)
    {
    	// Check Provider and get ConnectionString
    	if (Configuration["Database"] == "SQLite")
    	{
    		services.AddDbContext<DatabaseContext>(options =>
    			options.UseSqlite(Configuration.GetConnectionString("SQLite")));
    	}
    	else if (Configuration["Database"] == "MySQL")
    	{
    		services.AddDbContext<DatabaseContext>(options =>
    			options.UseMySql(Configuration.GetConnectionString("MySQL")));
    	}
    	else if (Configuration["Database"] == "MSSQL")
    	{
    		services.AddDbContext<DatabaseContext>(options =>
    			options.UseSqlServer(Configuration.GetConnectionString("MSSQL")));
    	}
    	else if (Configuration["Database"] == "PostgreSQL")
    	{
    		services.AddDbContext<DatabaseContext>(options =>
    			options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL")));
    	}
    	// Exception
    	else
    	{ throw new ArgumentException("Not a valid database type"); }
    }
