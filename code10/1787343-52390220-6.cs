    public void ConfigureServices(IServiceCollection services)
    {
    	// Check Provider and get ConnectionString
    	if (Configuration["Provider"] == "SQLite")
    	{
    		services.AddDbContext<DatabaseContext>(options =>
    			options.UseSqlite(Configuration.GetConnectionString("SQLite")));
    	}
    	else if (Configuration["Provider"] == "MySQL")
    	{
    		services.AddDbContext<DatabaseContext>(options =>
    			options.UseMySql(Configuration.GetConnectionString("MySQL")));
    	}
    	else if (Configuration["Provider"] == "MSSQL")
    	{
    		services.AddDbContext<DatabaseContext>(options =>
    			options.UseSqlServer(Configuration.GetConnectionString("MSSQL")));
    	}
    	else if (Configuration["Provider"] == "PostgreSQL")
    	{
    		services.AddDbContext<DatabaseContext>(options =>
    			options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL")));
    	}
    	// Exception
    	else
    	{ throw new ArgumentException("Not a valid database type"); }
    }
