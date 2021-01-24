    public List<object> RunQuery(SqlCommand command)
    {
        List<object> results = new List<object>();
        using (var dbConnection = new SqlConnection(_dbConnectionString))
        {
            try
            {
                dbConnection.Open();
    
                command.Connection = dbConnection;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Repeat for however many columns you have
                        results.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    
        return results;
    }
