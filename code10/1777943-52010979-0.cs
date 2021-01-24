    List<SomeObject> inventories = new List<SomeObject>();
    // add objects to list...
    string[] strArray = <<somevalues>>;
    // result will be stored here
    List<SomeObject> filtered = new List<SomeObject>();
    
    foreach (var itm in strArray)
    {
        // LIKE '%SOMEVALUE%'
        var match = inventories.Where(x => x.columnName.Contains(itm)).ToList();
        // LIKE '%SOMEVALUE'
        // var match = inventories.Where(x => x.columnName.StartsWith(itm)).ToList();
        // LIKE 'SOMEVALUE%'
        // var match = inventories.Where(x => x.columnName.EndsWith(itm)).ToList();
        foreach (var m in match)
            filtered.Add(m);
    }
    
    
     
