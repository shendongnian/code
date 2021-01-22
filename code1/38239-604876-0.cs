    using (SqlConnection conn = new SqlConnection(databaseConnectionString))
    {
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "StoredProcedureName";
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.AddWithValue("@ID", fileID);
    
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
    }
      
