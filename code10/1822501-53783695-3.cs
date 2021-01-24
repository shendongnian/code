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
            .Setup(s => s.FileHeaderWrite += (o, e) =>
            {
                e.HeaderText = "Test,Test2";
            })
            )
            w.Write(r);
    }
    
    Console.WriteLine(csvOut.ToString());
