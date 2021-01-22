    foreach(var g in groups)
        Console.WriteLine("{0}, {1}:{2}", 
            g.Key.Country, 
            g.Key.Age, 
            g.Aggregate(TimeSpan.Zero, (sum, x) => sum + x.TimeSpentOnSO));
