     string ConnectionString = "SERVER=localhost;" 
                        + "DATABASE=testdb;" 
                        + "User Id=wsuser;" 
                        + "PASSWORD=12345;" 
    
                         MySqlConnection Connection = new 
                         MySqlConnection(ConnectionString);
                         Connection.Open();
            
