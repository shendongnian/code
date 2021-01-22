    new Component {
        ID = 1, 
        Name = "MOBO", 
        Category = new Dictionary<int, string> { 
            { 3, "Beverages" }
            { 5, "Produce" }
        }.ToLookup(o => o.Key, o => o.Value)
    }
