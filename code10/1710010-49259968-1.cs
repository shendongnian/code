    using (SqlConnection connection = new SqlConnection(connectionString))
    {
       connection.Open();
       using (SqlCommand command1 = new SqlCommand(query1, connection))
       {
          // Execute command, etc. here
       }
    
       using (SqlCommand command2 = new SqlCommand(query2, connection))
       {
          // Execute command, etc. here
       }
    
       using (SqlCommand command3 = new SqlCommand(query3, connection))
       {
          // Execute command, etc. here
       }
    }
