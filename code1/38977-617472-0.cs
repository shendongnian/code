    List<Pair> list = new List<Pair>();
    
    list.Add(new Pair("DOC", "DocDate"));
    list.Add(new Pair("CON", "ConUserDate"));
    list.Add(new Pair("BAL", "BalDate"));
    
    foreach (var item in list)
    {
        string entType = item.First as string;
        string dateField = item.Second as string;
        // DO STUFF
    }
