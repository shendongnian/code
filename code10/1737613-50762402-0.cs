    using System.Data.Entity.Core.Common;
    using System.Data.SQLite;
    using System.Data.SQLite.EF6;
    
    namespace ClassLibrary1
    {
    	public class commonConfig : System.Data.Entity.DbConfiguration
    	{
    		public commonConfig()
    		{
    			SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory());
    			SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
    
    			SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
    			SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
    			SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
    		}
    	}
    }
