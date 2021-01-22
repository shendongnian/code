    using (SqlConnection connection = new SqlConnection(conn_string))
    {
        connection.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM MyTable"))
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            return result;
        }
    }
