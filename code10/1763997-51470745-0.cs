    // get the connection
    var db = DependencyService.Get< ISQLiteDB>();
    var conn = db.GetConnection();
    
    // create the tables
    if (conn != null) {
      await conn.CreateTableAsync<TodoItem>(Users);
      await conn.CreateTableAsync<TodoItem>(Retailer);
    }
