    static void Test(SqlConnection openConnection)
	{
		using(SqlCommand cmd = openConnection.CreateCommand())
		{
			cmd.CommandText =
				@"create table #Test 
				(bin varbinary(max), num int);
				insert into #Test (bin, num) 
				values (0x0000002D, 1);";
			cmd.ExecuteNonQuery();
			cmd.CommandText = "SELECT TOP 1 bin FROM #Test;";
			byte[] binValue = (byte[])cmd.ExecuteScalar();
			cmd.CommandText = "SELECT * FROM #Test WHERE bin = @bin;";
			var parameter = new SqlParameter("@bin", SqlDbType.VarBinary, -1);
            cmd.Parameters.Add(parameter);
            parameter.Value = binValue;
			DataTable table = new DataTable();
			using (var reader = cmd.ExecuteReader())
			{
				table.Load(reader);
			}
			Debug.Assert(table.Rows.Count == 1);
		}
	}
