    List<int> userIds = new List<int>();  //Have to declare your list in which you can store all userid's
    using (SqlConnection conn = new SqlConnection(conString))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT UserId, Status FROM NewUsers", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    userIds.Add(Convert.ToInt32(reader["UserId"].ToString()));
                }
            }
        }
    }
