    using (SqlConnection con = new SqlConnection(this.ConnectionString))
    using (SqlCommand cmd = CreateSprocCommand(con, "SomeSprocName", true, SqlDbType.Int)
    {
        cmd.Connection.Open();
        using (var reader = cmd.ExecuteReader())
        {
            //some code looping over the recors
        }
        //some more code to return whatever needs to be returned
    }
