    // get the connection
    var db = DependencyService.Get< ISQLiteDB>();
    var conn = db.GetConnection();
    
    // create the tables
    if (conn != null) {
      await conn.CreateTableAsync<Users>();
      await conn.CreateTableAsync<Retailer>();
    }
