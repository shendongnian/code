    List<string> names = new List<string>();
    using(SqlConnection db = new SqlConnection(ConfigurationManager...))
    {
        db.Open();
        SqlCommand cmd = new SqlCommand("Select ....", db);
    
        using(SqlDataRead rd = cmd.ExecuteReader())
        {
            while(rd.Read())
            {
               names.Add(rd.GetString(0);
            }
        }
    }
