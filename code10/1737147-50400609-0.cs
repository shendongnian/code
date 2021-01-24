	using (var conn = new SqlConnection(context.Database.Connection.ConnectionString))
	{
		using (var cmd = conn.CreateCommand())
		{
            cmd.CommandText = 
                string.Format("ALTER DATABASE [{0}] COLLATE Latin1_General_100_CI_AS",
                    context.Database.Connection.Database));
			conn.Open();
			cmd.ExecuteNonQuery();
		}
	}
