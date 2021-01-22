    var dic1 = new Dictionary<string, string>() 
    { 
        { "A", "s" },
        { "B", "d" },
        { "C", "a" },
        { "D", "w" },
    };
    var dic2 = new Dictionary<string, string>() 
    { 
        { "A", "z" },
        { "B", "e" },
        { "C", "r" },
        { "D", "t" },
    };
    var dic3 = new Dictionary<string, string>() 
    { 
        { "A", "i" },
        { "B", "o" },
        { "C", "u" },
        { "D", "p" },
    };
    var table = new DataTable();
    table.Columns.Add("K", typeof(string));
    table.Columns.Add("c1", typeof(string));
    table.Columns.Add("c2", typeof(string));
    table.Columns.Add("c3", typeof(string));
    foreach (var key in dic1.Keys)
    {
        table.Rows.Add(key, dic1[key], dic2[key], dic3[key]);
    }
