    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    //OR using (SqlConnection connection = Connection.Open())
    //If you want to keep your Connection class to avoid having to pass in connection string.  
        using (SqlCommand cmd = new SqlCommand(statement, connection))
        {
            ...
            cmd.ExecuteNonQuery ()
        }
    }
