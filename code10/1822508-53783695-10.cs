    StringBuilder csvIn = new StringBuilder(@"ID,Name
    1, David
    2, Bob");
    
    StringBuilder csvOut = new StringBuilder();
    
    using (var r = new ChoCSVReader(csvIn)
        .WithFirstLineHeader()
        )
    {
        using (var w = new ChoCSVWriter(csvOut)
            .WithFirstLineHeader()
            )
            w.Write(r.Select(r1 => new { Test1 = r1.ID, Test2 = r1.Name }));
    }
    
    Console.WriteLine(csvOut.ToString());
