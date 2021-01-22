    List<Member> members = new List<Member>();
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(queryString, connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Member member = new Member();
                    member.UserName = reader.GetString(0);
                    member.FirstName = reader.GetString(1);
                    member.LastName = reader.GetString(2);
                    members.Add(member);
                }
            }
        }
    }
    foreach(Member member in members)
    {
        // do something
    }
