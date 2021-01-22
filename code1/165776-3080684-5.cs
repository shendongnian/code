    using System.Configuration;  // for ConfigurationManager
    using System.Data;           // for all interface types
    using System.Data.Common;    // for DbProviderFactories
    var cs = ConfigurationManager.ConnectionStrings["SomeConnection"];
    //                                              ^^^^^^^^^^^^^^^^
    var factory = DbProviderFactories.GetFactory(cs.ProviderName);
    //                                           ^^^^^^^^^^^^^^^
    using (IDbConnection connection = factory.CreateConnection())
    {
        connection.ConnectionString = cs.ConnectionString;
        //                            ^^^^^^^^^^^^^^^^^^^
        connection.Open();
        try
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                ...  // do something with the database
            }
        }
        finally
        {
            connection.Close();
        }
    }
