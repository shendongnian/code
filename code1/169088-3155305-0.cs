    string connString = "...";
    string cmdText = @"INSERT INTO Test(col1, col2) VALUES (@col1, @col2)";
    using (SqlConnection conn = new SqlConnection(connString))
    {
    	using (SqlCommand cmd = new SqlCommand(cmdText, conn))
    	{
    		cmd.Parameters.Add("@col1", SqlDbType.NVarChar).Value = ""; // or .Value=DBNull.Value;
    		cmd.Parameters.Add("@col2", SqlDbType.DateTime).SqlValue = default(SqlDateTime); // or .Value=DBNull.Value;
    	}
    }
