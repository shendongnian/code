    //typical configuration part of .net core
    public void ConfigureServices(IServiceCollection services)
    {
        //some mvc 
        services.AddMvc();
      
        //hey, options!
        services.AddDbContext<BlexzWebDb>(options => 
               options.UseSqlServer(Configuration.GetConnectionString("BlexzWebConnection")));
    ...etc
