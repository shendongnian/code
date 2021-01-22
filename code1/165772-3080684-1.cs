    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    var cs = ConfigurationManager.ConnectionStrings["SomeConnection"];
    var factory = DbProviderFactories.GetFactory(cs.ProviderName);
    using (IDbConnection conn = factory.CreateConnection())
    {
        conn.ConnectionString = cs.ConnectionString;
        conn.Open();
        try
        {
            using (IDbCommand cmd = conn.CreateCommand())
            {
                ...
            }
        }
        finally
        {
            conn.Close();
        }
    }
