     var connection = new SQLiteAsyncConnection(YourDBPath);
     connection.CreateTableAsync<Login>().Wait();
     connection.CreateTableAsync<User>().Wait();
     connection.InsertWithChildrenAsync(YourItem);
  
