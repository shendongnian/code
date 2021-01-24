    var MyEmails= new List<Email>();
    SqlCommand command = new SqlCommand(queryString, connection);
    SqlDataReader reader = command.ExecuteReader();
    while (reader.Read())
    { 
       MyEmails.Add(new Email(){email=reader[0].ToString()}); // as an example 
    }
