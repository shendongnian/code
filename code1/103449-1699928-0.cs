    // Microsoft Access provider factory
    DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
    DataTable userTables = null;
    using (DbConnection connection = factory.CreateConnection()) {
      // c:\test\test.mdb
      connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\test\\test.mdb";
      // We only want user tables, not system tables
      string[] restrictions = new string[4];
      restrictions[3] = "Table";
    
      connection.Open();
    
      // Get list of user tables
      userTables = connection.GetSchema("Tables", restrictions);
    }
    List<string> tableNames = new List<string>();
    for (int i=0; i < userTables.Rows.Count; i++)
        tableNames.Add(userTables.Rows[i][2].ToString());
