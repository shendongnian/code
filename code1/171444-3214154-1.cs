    var results = db.Table.Select(); // Your query here
    int rowCount = results.Count(); // Count rows once and store
    
    for(int i = 0; i <= rowCount; i += 50)
    {
        var paged = results.Skip(i).Take(50);
    
        // do the calculations with the groups of 50 here
    }
