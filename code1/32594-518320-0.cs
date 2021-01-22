    try
    {
    
     using (var conn = new SqlConnection("..."))
     {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "...";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // ...
                }
            }
        }
     }
    }
    catch(Exception ex)
    {
    //Handle, log, rethrow exception
    }
