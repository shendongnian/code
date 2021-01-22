    Dim conn as New SQLConn();
    Dim sqlConnection New SQLConnection();
    
    sqlConnection = conn.Connection();
    
    using (sqlConnection) 
    { 
        String query = "Select * from table";
        objSql = new SqlCommand(query, sqlConnection);      
    
        conn.Open(); 
        DoSomething(); 
    }
