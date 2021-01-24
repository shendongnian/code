    using System.Data.Entity;
    using System.Data.Entity.Core.Common;
    using System.Data.SQLite.EF6;
    
    class MyDbConfiguration : DbConfiguration
    {
    	public MyDbConfiguration()
    	{
    		SetProviderFactory(SQLiteProviderInvariantName.ProviderName, SQLiteProviderFactory.Instance);
    		SetProviderServices(SQLiteProviderInvariantName.ProviderName, (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
    		AddDependencyResolver(new SQLiteDbDependencyResolver());
    	}
    }
