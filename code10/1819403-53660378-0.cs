    using (SqlConnection con = new SqlConnection(ConnectionString))
    {
        SqlCommand cmd = new SqlCommand("Select * From Users Where UserID=@username And Password=@password", con);
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
       //rest of the code ...
    }
