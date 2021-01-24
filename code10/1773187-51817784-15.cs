    using (var conn = new SqlConnection(connectionstring))  
    {  
        conn.Open();
        using(var comm = new SqlCommand("select * from FooBar where foo = @foo", conn))
        {
            comm.Parameters.Add(new SqlParameter("@foo", "bar"));
            using(var reader = comm.ExecuteReader())
            {
                // Do stuff with the reader;
            }
        }
    } 
