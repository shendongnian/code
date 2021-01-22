    static void Main(string[] args)
    {
        // Create the connection.
        using (SqlConnection connection = new SqlConnection(@"Data Source=..."))
        {
            // Open the connection.
            connection.Open();
    
            // Create the command.
            using (SqlCommand command = new SqlCommand("xsp_Test", connection))
            {
                // Set the command type.
                command.CommandType = System.Data.CommandType.StoredProcedure;
    
                // Add the parameter.
                SqlParameter parameter = command.Parameters.Add("@dt",
                    System.Data.SqlDbType.DateTime);
    
                // Set the value.
                parameter.Value = DateTime.Now;
    
                // Make the call.
                command.ExecuteNonQuery();
            }
        }
    }
