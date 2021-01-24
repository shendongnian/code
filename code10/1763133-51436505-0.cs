     struct FD
        {
            public string name;
            public double[] CE;
        }
    
        struct FD2
        {
            public FD2(string name, IEnumerable<double>ce)
            {
                Name = name;
                CE = new ReadOnlyCollection<double>(new List<double>(ce));
            }
            public readonly string Name;   
            public readonly IReadOnlyList<double> CE;
        }
