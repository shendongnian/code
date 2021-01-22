    SqlConnection connection = new SqlConnection(-connection string-);
    
    SqlCommand command = new SqlCommand("...your sql query here...", connection);
    
    connection.Open();
    
    command.ExecuteScalar / command.ExecuteReader / command.ExecuteNonQuery
    (depending on your needs)
    
    connection.Close();
