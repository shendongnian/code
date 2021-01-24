    using(SqlConnection conn = new SqlConnection(/* args */))
    {
        using(SqlCommand com = new SqlCommand())
        {
            com.Connection = conn;
            com.CommandText = /*your query goes here */ ;
            conn.Open();
            using(SqlDataReader reader = com.ExecuteReader())
            {
                // read your result here and manipulate them
            }
        }
    }
