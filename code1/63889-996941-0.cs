    using(System.Data.IDbConnection conn = //create your connection here)
    {
        using(System.Data.IDbCommand cmd = conn.CreateCommand())
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddXYZ";
    
            // add your parameters here using cmd.CreateParameter() and cmd.Parameters.Add()
    
            using(System.Data.IDbDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    // read your results row-by-row
                }
            }
        }
    }
