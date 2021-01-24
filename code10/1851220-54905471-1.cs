    public class CustomDbContext : DbContext
    {
        static CustomDbContext()
        {
			Database.SetInitializer<CustomDbContext>(null);
			DbInterception.Add(new SchemaInterceptor());
        }
        public CustomDbContext(IConnectionStringProvider provider)
            : base(provider.ConnectionString)
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
    		modelBuilder.HasDefaultSchema("RemoveThisDefaultSchema");
            modelBuilder.Configurations.Add(new SomeEntityMap());
            modelBuilder.Configurations.Add(new SomeOtherEntityMap());
        }
    }
    
    public class SchemaInterceptor : IDbCommandInterceptor
    {
    	public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    	{
    	}
    
    	public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    	{
    		command.CommandText = command.CommandText.Replace("[RemoveThisDefaultSchema].", string.Empty);
    	}
    
    	public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    	{
    	}
    
    	public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    	{
    		command.CommandText = command.CommandText.Replace("[RemoveThisDefaultSchema].", string.Empty);
    	}
    
    	public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    	{
    	}
    
    	public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    	{
    		command.CommandText = command.CommandText.Replace("[RemoveThisDefaultSchema].", string.Empty);
    	}
    }
    	
