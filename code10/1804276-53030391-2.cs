    string queryString = "select email,status from tableemail";
    string updateString = "UPDATE tableemail set status=1 where email = @email";
    using (OleDbConnection connection = new OleDbConnection("Provider = OraOLEDB.Oracle.1; Data Source = xe;
     Password=eppspps;User ID = xpress; unicode=true"))
    {
     connection.Open();
     OleDbCommand cmd = new OleDbCommand(queryString,Connection);
     OleDbCommand cmd2 = new OleDbCommand(updateString,Connection);
     OleDbDataReader reader = cmd.ExecuteReader();
     
     while (reader.Read()) 
     {
         MailAddress to = new MailAddress(reader[0].ToString());
         message.To.Add(to);     
    	 if(!reader.IsDBNull(1)){
    	     cmd2.Parameters.Clear();
    		 cmd2.Parameters.Add(new OleDbParameter("email", reader["email"]));
    		 cmd2.ExecuteNonQuery();
    	 }
      }
    }
