    var userIds = new List<int>();
    using (SqlConnection conn = new SqlConnection(conString))
    using (SqlCommand cmd = new SqlCommand("SELECT UserId,Status FROM NewUsers", conn))
    {
        conn.Open();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            {
                userIds.Add((int)reader["UserId"]);
            }
        }
    }
