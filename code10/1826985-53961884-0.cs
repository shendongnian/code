    SqlConnectionStringBuilder builder = new 
    SqlConnectionStringBuilder();
    builder.DataSource = ".";                
    builder.InitialCatalog = "DATABASE";
    builder.IntegratedSecurity = true;
    SqlConnection connection = new 
    SqlConnection(builder.ConnectionString);
    connection.Open();
