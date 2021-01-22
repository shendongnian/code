        public static string GetRemoteConnectionString()
        {
            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
              DataSource = $"{IP},{PORT}", // ex : 37.59.110.55,1433 
              InitialCatalog = "MyDatabaseName",  //Database
              IntegratedSecurity = false,
              MultipleActiveResultSets = true,
              ApplicationName = "EntityFramework",
              UserID = "MyUserId",
              Password = "MyPassword"
            };
            return sqlString.ToString();
        }
