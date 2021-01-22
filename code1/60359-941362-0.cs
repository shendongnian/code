    // the following code has parts left out for brevity...
    using(var conn = new SqlConnection( ... ))
    using(var cmd = new SqlCommand( ... ))
    {
        conn.Open();
    
        using(var reader = cmd.ExecuteReader())
        {
            // do whatever with the reader here...
        }
    }
