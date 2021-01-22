    string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Samples\\login.mdb";
    
    using (OleDbConnection myConnection = new OleDbConnection(connectionString))
    {
    	myConnection.Open();
    	
    	string query = "INSERT INTO LOGIN_TABLE (UserName, Password) VALUES (?, ?)";
    
    	OleDbCommand myCommand = new OleDbCommand(query, myConnection);
    
    	myCommand.Parameters.Add("UserName", OleDbType.VarChar, 50);
    	myCommand.Parameters.Add("Password", OleDbType.VarChar, 50);
    	
    	myCommand.Parameters[0].Value = textBox1.Text;
    	myCommand.Parameters[1].Value = textBox2.Text;
    
    	myCommand.Prepare();
    	myCommand.ExecuteNonQuery();
    }
