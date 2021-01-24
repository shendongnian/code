    // make your connectionString variable dynamic based on your connection type
    if(connType == "SQL")
      context = new DbContext(sQLConnectionString);
    else
      context = new DbContext(sQLLiteConnectionString);
