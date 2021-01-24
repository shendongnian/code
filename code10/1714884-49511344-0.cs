    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    	if (optionsBuilder.IsConfigured)
    	{
    		base.OnConfiguring(optionsBuilder);
    		return;
    	}
    
    	string pathToContentRoot = Directory.GetCurrentDirectory();
    	string json = Path.Combine(pathToContentRoot, "appsettings.json");
    
    	if (!File.Exists(json))
    	{
    		string pathToExe = Process.GetCurrentProcess().MainModule.FileName;
    		pathToContentRoot = Path.GetDirectoryName(pathToExe);
    	}
    
    	IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
    		.SetBasePath(pathToContentRoot)
    		.AddJsonFile("appsettings.json");
    
    	IConfiguration configuration = configurationBuilder.Build();
    
    	optionsBuilder.UseSqlServer(configuration.GetConnectionString("RecipeDatabase"));
    
    	base.OnConfiguring(optionsBuilder);
    }
