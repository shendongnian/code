    using (var conn = new SqlConnection(connectionstring))
    {
        using (var comm = new SqlCommand("FooBarProcedure", conn) { CommandType = CommandType.StoredProcedure }) 
        {
             comm.Parameters.Add(new SqlParameter("@FooBar", "shizzle"));
             conn.Open();
             comm.ExecuteNonQuery();
        }
    }
