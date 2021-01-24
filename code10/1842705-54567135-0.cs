	public static void GetRs(string sql, Action<DataTableReader> consumer)
	{
		using (var con = NewSqlConnection())
		{
			con.Open();
			GetRs(sql, con, consumer);
		}
	}
	
	public static void GetRs(string sql, SqlConnection dbconn, Action<DataTableReader> consumer)
	{
		using (var cmd = new SqlCommand(sql, dbconn))
		{
			if (dbconn.State == ConnectionState.Closed)
			{
				dbconn.Open();
			}
			DataTable myTable = new DataTable();
			var reader = cmd.ExecuteReader();
			myTable.Load(reader);
			consumer(myTable.CreateDataReader());
		}
	}
