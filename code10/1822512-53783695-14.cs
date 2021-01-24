    StringBuilder csvIn = new StringBuilder(@"ID,Name,Date
    1, David, 1/1/2018
    2, Bob, 2/12/2019");
    
    using (var r = new ChoCSVReader(csvIn)
        .WithFirstLineHeader()
        .WithMaxScanRows(2)
        )
    {
        foreach (IDictionary<string, object> rec in r.Take(1))
        {
            foreach (var kvp in rec)
                Console.WriteLine($"{kvp.Key} - {r.Configuration[kvp.Key].FieldType}");
        }
    }
