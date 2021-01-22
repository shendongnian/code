    using (SqlConnection conn = new SqlConnection(myConnectionString))
    using (SqlCommand cmd = conn.CreateCommand())
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "up_action"
        cmd.Parameters.AddWithValue("@group", group);
        cmd.Parameters.AddWithValue("@nom", nom);
        cmd.Parameters.AddWithValue("@compte", compte);
        conn.Open();
        using (SqlDataReader rd = cmd.ExecuteReader())
        {
            if (rd.Read())
            {
                chrono = rs["chrono"];
            }
        }
    }
