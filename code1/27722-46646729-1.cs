    private static IEnumerable<string> GetSchema(string connectionString, string tableName)
            {
    
         
    
       using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "sp_Columns";
                command.CommandType = CommandType.StoredProcedure;
    
                command.Parameters.Add("@table_name", SqlDbType.NVarChar, 384).Value = tableName;
    
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return (string)reader["column_name"];
                    }
                }
            }
        }
