    var results = await db.Table<Database.Inventory>();
    
    var query = conn.Table<Database.Inventory>();
    
    query.ToListAsync().ContinueWith((t) =>
    {
        foreach (var N in t.Result)
        {
          // code from your foreach loop
        }
    });
