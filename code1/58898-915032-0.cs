    using (var c = conn.Connection()) // <==edit
    { 
        String query = "Select * from table";
        objSql = new SqlCommand(query, c); // <==edit
    
        c.Open(); 
        DoSomething(); 
    }
