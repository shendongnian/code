    using System.Data.Entity;
    using System.Data.SqlClient;
    
    namespace ClassLibrary1
    {
    	[DbConfigurationType(typeof(commonConfig))]
    	public class MsSqlDbContext : DbContext
    	{
    		public MsSqlDbContext(SqlConnection existingConnection,
    								 bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
    		{
    			DbConfiguration.SetConfiguration(new commonConfig());
    		}
    
    		public DbSet<SomeTableEntity> SomeTable { get; set; }
    	}
    }
