    private string connectionString;
    public InsigContext(DbContextOptions<InsigContext> options,IConfiguration configuration)
                                                                              : base(options)
    { 
      connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection")
                                         .Value;
    }
    // you can use this.connectionString now
