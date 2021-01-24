    using System.Data.Entity;
    using System.Data.SQLite;
    
    namespace ClassLibrary1
    {
    	[DbConfigurationType(typeof(commonConfig))]
    	public class SqliteDbContext : DbContext
    	{
    		public SqliteDbContext(SQLiteConnection existingConnection,
    							bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
    		{
    			DbConfiguration.SetConfiguration(new commonConfig());
    		}
    
    		public DbSet<SomeDbTableEntity> SomeTable { get; set; }
    	}
    }
