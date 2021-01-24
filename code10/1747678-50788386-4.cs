    //typical configuration part of .net core
    public void ConfigureServices(IServiceCollection services)
    {
        //some mvc 
        services.AddMvc();
        //some sql server ef
        services.AddEntityFrameworkSqlServer();
        //hey, options!
        services.AddDbContext<BlexzWebDb>(options => 
               options.UseSqlServer(Configuration.GetConnectionString("BlexzWebConnection")));
    ...etc
