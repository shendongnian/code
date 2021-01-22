    string csv = @"Id, Name, City
    1, Tom, NY
    2, Mark, NJ
    3, Lou, FL
    4, Smith, PA
    5, Raj, DC
    ";
    
    StringBuilder sb = new StringBuilder();
    using (var p = ChoCSVReader.LoadText(csv)
        .WithFirstLineHeader()
        )
    {
        using (var w = new ChoXmlWriter(sb)
            .Configure(c => c.RootName = "Employees")
            .Configure(c => c.NodeName = "Employee")
            )
            w.Write(p);
    }
    
    Console.WriteLine(sb.ToString());
