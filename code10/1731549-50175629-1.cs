    public string GetUserProfile(string login)
    {
        string sql = select profile from user where name = @login";
        // I assume Connect() returns an *open* connection?
        using (var conn = new Database().Connect())
        {
            using (var command = new SqlCommand(sql, conn))
            {
                command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;
                using (var reader = command.ExecuteReader())
                {
                    // If it's an error (code failure) for there to be no matching profile,
                    // you may want to throw an exception instead.
                    return s.Read() ? s.GetString(0) : null;
                }
            }
        }
    }
