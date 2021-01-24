    int foundID = -1;
    using (SqlConnection conn = new SqlConnection("<your connection string>")) 
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT id FROM reserving WHERE id=@orderID;", conn);
        cmd.Parameters.AddWithValue("@orderID", item.Id);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                foundID = reader["id"];
            }
        }
        conn.Close();
    }
