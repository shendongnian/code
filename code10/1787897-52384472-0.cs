    public string GetRole(string userName)
    {
        using (SqlConnection dbConn = new SqlConnection(_connectionString))
        {
            dbConn.Open();
            try
            {
                var query = @"select r.rname from role r
                                join account_role ar
                                  on r.roleid = ar.roleid
                                join account a
                                  on a.aid = ar.aid
                              where a.username = ""@userName""";
                using (SqlCommand dbCommand = new SqlCommand(query, dbConn))
                {
                    dbCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = userName;
                    SqlDataReader reader = dbCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        var result = reader.GetString(0);
                    }
                }
            }
            catch (SqlException)
            {
                throw; // bubble up the exception and preserve the stack trace
            }
            dbConn.Close();
            return result;
        }
    }
