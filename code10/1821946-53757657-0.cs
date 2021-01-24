    using(var con = new SqlConnection(ConnectionString))
    {
        using(var cmd = new SqlCommand("spCheckIfNameExist", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
            con.Open()
            var tNames = cmd.ExecuteScalar().ToString();
        }
    }
        
