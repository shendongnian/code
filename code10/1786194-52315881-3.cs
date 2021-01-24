    var userIds = new List<int>();
    using (var conn = new SqlConnection(conString))
    using (var cmd = new SqlCommand("SELECT UserId,Status FROM NewUsers", conn))
    {
        conn.Open();
        using (var reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            {
                userIds.Add((int)reader["UserId"]);
            }
        }
    }
