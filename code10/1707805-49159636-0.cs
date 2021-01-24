    using System.Data.Entity;
    
    protected void Application_Start()
    {
        Database.SetInitializer<ApplicationDbContext>(null);
        ...
    }
