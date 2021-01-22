    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    var cs = ConfigurationManager.ConnectionStrings["SomeConnection"];
    // ^ retrieves connection string item from app.config.
    var factory = DbProviderFactories.GetFactory(cs.ProviderName);
    // ^ creates a factory for the right provider
    using (IDbConnection conn = factory.CreateConnection())
    {                        // ^ create connection object through the factory.
        conn.ConnectionString = cs.ConnectionString;
        // ^ copy over the actual connection string from app.config.
        conn.Open();
        try
        {
            using (IDbCommand cmd = conn.CreateCommand())
            {                    // ^ create command through the connection object. 
                ...  // do something
            }
        }
        finally
        {
            conn.Close();
        }
    }
