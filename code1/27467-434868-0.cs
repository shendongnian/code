        string provider = "System.Data.SqlClient"; // for example
        DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
        using(DbConnection conn = factory.CreateConnection()) {
            conn.ConnectionString = cs;
            conn.Open();
        }
