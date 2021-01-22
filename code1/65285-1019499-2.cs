    ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["LoremIpsum"];
    SqlConnectionStringBuilder builder;
    LINQTOSQLDataClassDataContext db;
     
    if (null != settings) 
    {   
        string connection = settings.ConnectionString;  
        builder = new SqlConnectionStringBuilder(connection);
    
       // passwordTextBox being the control where joe the user actually enters his credentials
     
        builder.Password =passwordTextBox.Text;  
        db = new LINQTOSQLDataClassDataContext(builder.ConnectionString);
     } }
