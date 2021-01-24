    using (var conn = new SqlConnection(connectionstring))
    {
        conn.Open();
        using (var comm = new SqlCommand("FooBarProcedure", conn) { CommandType = CommandType.StoredProcedure }) 
        {
             comm.Parameters.Add(new SqlParameter("@FooBar", "shizzle"));
             comm.ExecuteNonQuery();
        }
    }
