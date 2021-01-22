    using(SqlConnection conn = new SqlConnection(connStr))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("sp_UpdatetoShipped", conn))
        {
        }
    }
