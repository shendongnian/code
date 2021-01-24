    var connectionString = $"<connection string here>";
    string sqlStatement = "<a valid query goes here>";
    
    var connection = new DB2Connection(connectionString);
    DB2Command myCommand = new DB2Command(sqlStatement,connection);
    
    connection.Open();
    
    try 
    {
      DB2DataReader reader = myCommand.ExecuteReader(CommandBehavior.KeyInfo);
    
      DataTable dt = reader.GetSchemaTable();
    
      reader.Close();
    }
    finally 
    {
      connection .Close();
    }
