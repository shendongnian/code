    // 1.  Create your SQL Connection
    SqlConnection conn = null; 
    
    // 2.  Create and open a connection object
    conn = new SqlConnection("Connection String Goes Here"); 
    
    // 3.  Open the Connection
    conn.Open(); 
    
    // 4.  Create the SQL Command and assign it it a string
    string strSQLCommand = "SELECT * FROM TABLE"; 
    
    // 5.  Execute the SQL Command
    SqlCommand command = new SqlCommand(strSQLCommand, conn); 
    
    // 6.  Use ExecuteScalar() to return the first result
    string returnvalue = (string)command.ExecuteScalar(); 
    
    // 7.  Close the Connection
    conn.Close(); 
    
    // 8.  Return the Value
    return returnvalue; 
