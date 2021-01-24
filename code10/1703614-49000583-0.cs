    async Task InitializeAsync()
    {
         // Short circuit - local database is already initialized
         if (Client.SyncContext.IsInitialized)
             return;
         // Create a reference to the local sqlite store
         var store = new MobileServiceSQLiteStore("offlinecache.db");
         // Define the database schema
         store.DefineTable<TodoItem>();
         // Actually create the store and update the schema
         await Client.SyncContext.InitializeAsync(store);
    }
