    internal sealed class Configuration : DbMigrationsConfiguration<YourContext>
    {
    	public Configuration()
    	{
    		AutomaticMigrationsEnabled = false;
    		ContextKey = "YourContext_";
    	}
    
    	protected override void Seed(YourContext context)
    	{
    		//Migrate your data
    	}
    }
