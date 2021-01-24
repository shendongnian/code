    string query = "SELECT COUNT(Movie.Code) FROM Movie WHERE Movie.Code = @code";
    int i = 0;
    using (SqlCommand cmd = new SqlCommand(query))
    {
        cmd.Connection = con;
        con.Open();
        i = (Int32)cmd.ExecuteScalar();
        if(i > 0)
        {
            // OK
        }
        else
        {
            // Fail
        }
    }
