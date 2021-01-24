    OleDbCommand cmd = null;
             
    string queryString = "select email,status from tableemail";
    using (OleDbConnection connection = new OleDbConnection("Provider = OraOLEDB.Oracle.1; Data Source = xe;
     Password=eppspps;User ID = xpress; unicode=true"))
    {
     OleDbCommand command= new OleDbCommand(queryString, connection);
     connection.Open();
     cmd = new OleDbCommand(queryString);
     cmd.Connection = connection;
     OleDbDataReader reader = cmd.ExecuteReader();
    
     while (reader.Read()) 
     {
    	 MailAddress to = new MailAddress(reader[0].ToString());
    	 message.To.Add(to);     
     }
      cmd.CommandText = " UPDATE tableemail set status=1 where status is null";
      cmd.ExecuteNonQuery();
    }
