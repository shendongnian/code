    string query = @"SELECT [Contact First Name] 
                    FROM ContactSkillSet 
                    WHERE [Contact ID] = @Current";
    string result;
    using(SqlConnection conn = new SqlConnection(connString))
    {
        conn.Open();
        using(SqlCommand command = new SqlCommand(query, conn))
        {
            result = (string)command.ExecuteScalar();
        }
    }
