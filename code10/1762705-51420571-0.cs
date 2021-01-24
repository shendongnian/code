	public List<ActiveUsers> getDatabases()
	{
		//passing query
		string SqlQuery = "SELECT [WorkspaceName],[MaConfig_Customers].Name  FROM [MaConfig_CustomerDatabases] INNER JOIN [MaConfig_Customers] ON [MaConfig_CustomerDatabases].CustomerId = [MaConfig_Customers].CustomerId where [MaConfig_Customers].Status = 0";
		//creating connection
		string sqlconn = ConfigurationManager.ConnectionStrings["MaxLiveConnectionString"].ConnectionString;
		
		using(con = new System.Data.SqlClient.SqlConnection(sqlconn))
		using(var cmd = new SqlCommand(SqlQuery, con))
		{
			con.Open();
			using(SqlDataReader reader = cmd.ExecuteReader())
			{
				List<ActiveUsers> results = new List<ActiveUsers>();
				while (reader.Read())
				{
					ActiveUsers company = new ActiveUsers();
					company.DatabaseName = reader.GetString(0);
					company.ClientName = reader.GetString(1);
					results.Add(company);
				}
			}
		}
		return results;
	}
