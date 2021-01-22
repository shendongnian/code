    using (SqlConnection conn = new SqlConnection())
    {
        SqlCommand cmd = new SqlCommand("sproc", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        // add parameters
        SqlParameter outputParam = cmd.Parameters.Add("@ID", SqlDbType.Int);
        outputParam.Direction = ParameterDirection.Output;
        conn.Open();
        using(IDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            {
                //read in data
            }
        }
        // reader is closed/disposed after exiting the using statement
        int id = outputParam.Value;
    }
