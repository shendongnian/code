    string sql = "MyProcedureName";
    
    using (var cn = new SqlConnection(databaseConnectionString))
    using (var cmd = new SqlCommand(sql, cn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ParameterName", SqlDbType.VarChar, 50)
            .Value = "MyParameterValue";
    
        conn.Open();
        using (SqlDataReader rdr =
                   cmd.ExecuteReader(CommandBehavior.CloseConnection))
        {
            if (rdr.Read())
            {
                // process row from resultset;
            }
        }
    }
