    var db = new SQLiteAsyncConnection(Database.DatabasePath);
    foreach ( var N in db.Table<Database.Inventory>() ) // Table<T> does *not* return a List<T>!!
    {
        InventoryItems.Add(new Store_Listing 
        { 
            Id = N.Id, 
            Description = N.Description, 
            Style = N.Style 
        });
    }
