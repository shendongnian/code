    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(youCurrrentConnectionString);
    
    builder.UserID = userName;
    builder.Password = userPassword;
 
    //usage 
    ConnectionString = builder.ConnectionString;
    
