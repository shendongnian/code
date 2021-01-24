    StringBuilder csvIn = new StringBuilder(@"ID,Name
    1, David
    2, Bob");
    
    using (var r = new ChoCSVReader(csvIn)
        .WithFirstLineHeader()
        )
    {
            foreach (IDictionary<string, object> rec in r)
            {
                 var keys = rec.Keys.ToArray();
            }
    }
