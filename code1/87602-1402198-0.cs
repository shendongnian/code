    using (var conn = new SqlConnection(myConnectionString))
    using (var cmd = new SqlCommand("SELECT * FROM Jobs WHERE JobDate = @JobDate", conn))
    {
        cmd.Parameters.Add(new SqlParameter("@JobDate", 
            Convert.ToDateTime(dtpJobDate.Text)));
    
        conn.Open();
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // your code here to deal with the records...
            }
        }
    }
