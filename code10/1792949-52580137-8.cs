Startup
    private IConfiguration Configuration { get; set; }
    public void ConfigureServices(IServiceCollection services) {
    
        //...
        
        var connectionString = Configuration["AzureTableStorageConnectionString"];
        var cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
        CloudTableClient tableClient = cloudStorageAccount.CreateCloudTableClient();
        
        services.AddScoped<IAzureTableConnection>(_ => new AzureTableConnection(tableClient));
        
        //...
    }
    
