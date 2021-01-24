        TestModel[] list = new[]
        {
            new TestModel{ Id=1, Name="audi"},
            new TestModel{ Id=2, Name="BMW"},
            new TestModel{ Id=3, Name="audi"},
            new TestModel{ Id=4, Name="benz"},
            new TestModel{ Id=5, Name="audiq5"},
            new TestModel{ Id=6, Name="BMWx5"},
        };
        foreach(var match in FindSimilarModelPairs(list))
        {
            Console.WriteLine($"[{match.Item1.ToString()},{match.Item2.ToString()}");
        }
        Console.WriteLine("Press 'Enter'");
        Console.ReadLine();
