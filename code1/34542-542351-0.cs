    // Establishing connection
    
    SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder(); 
    cb.DataSource = "SQLProduction"; 
    cb.InitialCatalog = "Sales"; 
    cb.IntegratedSecurity = true;
    SqlConnection cnn = new SqlConnection(cb.ConnectionString);  
    
    // Getting source data
    
    SqlCommand cmd = new SqlCommand("SELECT * FROM PendingOrders",cnn); 
    cnn.Open(); 
    SqlDataReader rdr = cmd.ExecuteReader(); 
    
    // Initializing an SqlBulkCopy object
    
    SqlBulkCopy sbc = new SqlBulkCopy("server=.;database=ProductionTest;" +
                                      "Integrated Security=SSPI"); 
    
    // Copying data to destination
    sbc.DestinationTableName = "Temp"; 
    sbc.WriteToServer(rdr); 
    
    // Closing connection and the others
    
    sbc.Close(); 
    rdr.Close(); 
    cnn.Close(); 
