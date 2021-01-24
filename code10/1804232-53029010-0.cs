    String constr = (@"Data source=(localdb)\MSSQLLocalDB; initial catalog=DataHRD; integrated security=true;");
    // Create a new SqlConnectionStringBuilder and
    // initialize it with a few name/value pairs.
    SqlConnectionStringBuilder builder =
       new SqlConnectionStringBuilder(constr);
    
        
    // Now that the connection string has been parsed,
    // you can work with individual items.
    builder["Data Source"] = @"C:\Users\SONY\Desktop\asda\asd\MainMenu\DataHRD.mdf"
    // or anything else
    builder.Password = "new@1Password";
    builder.AsynchronousProcessing = true;
    
    // You can refer to connection keys using strings, 
    // as well. When you use this technique (the default
    // Item property in Visual Basic, or the indexer in C#),
    // you can specify any synonym for the connection string key
    // name.
    builder["Server"] = ".";
    builder["Connect Timeout"] = 1000;
    builder["Trusted_Connection"] = true;
