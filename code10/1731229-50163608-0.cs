    public void ConfigureServices(IServiceCollection services)
    {
        // Add application services.
           services.AddSingleton<IDataAccess, SQLAccess>(opt=> { new SQLAccess(new 
           Settings(){ 
               //Set Settings object properties here
    
           }); 
       });
    }
 
