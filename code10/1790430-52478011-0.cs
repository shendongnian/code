    List<(string Name, Table Table)> list = new List<(string, Table)>();
    // or simply
    var list = new List<(string Name, Table Table)>();
    
    Parallel.ForEach(list, t => 
    {
        // do something with t.Name, t.Table
        var name = t.Name;
        var table = t.Table;
    });
