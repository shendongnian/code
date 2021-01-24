    SqlCommand cmdMyEmails = new SqlCommand("GetAddress", connection);
    cmdMyEmails.CommandType = CommandType.StoredProcedure;
    SqlDataReader reader = command.ExecuteReader();
    while (reader.Read())
    { 
       string Emailid =  reader["Email"].ToString(); 
    }
