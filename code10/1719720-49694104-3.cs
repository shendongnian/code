            public static SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
            connectionString.DataSource = "(localdb)\\MSSQLLocalDB";
            connectionString.AttachDBFilename = "|DataDirectory|\\MyData.mdf";
            connectionString.IntegratedSecurity = true;
            string connectString = connectionString.ConnectionString;
            SqlConnection connection = new SqlConnection(connectString);
            return connection;
        }
