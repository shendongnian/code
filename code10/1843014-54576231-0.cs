    public class AntContext: DbContext 
    {
        public AntContext(): base("AntContext") 
        {
            Database.SetInitializer<AntContext>(new CreateDatabaseIfNotExists<AntContext>());    
        }
    
        //snip
    }
