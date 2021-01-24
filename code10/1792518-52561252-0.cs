    //create a stringbuilder
    StringBuilder sb = new StringBuilder();
    
    //create a connection to the database 
    using (SqlConnection connection = new SqlConnection(Common.connectionString))
    using (SqlCommand command = new SqlCommand("SELECT TITLES FROM DOCUMENTS WHERE AC_DATE = GETDATE()", connection))
    {
        //open the connection
        connection.Open();
    
        //create a reader
        SqlDataReader reader = command.ExecuteReader();
    
        //loop all the rows in the database
        while (reader.Read())
        {
            //add the title to the stringbuilder
            sb.AppendLine(reader["TITLES"].ToString());
        }
    }
    
    //create the mail message with the titles
    mailMessage.Body = sb.ToString();
