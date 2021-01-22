    var under = colStates.Where(c => (decimal)c.Value / (decimal)totalCount < .05M);
    var over = colStates.Where(c => (decimal)c.Value / (decimal)totalCount >= .05M);
    var newColStates = over.Union(new Dictionary<string, int>() { { "Other", under.Sum(c => c.Value) } });
    
    foreach (var item in newColStates)
    {
        Console.WriteLine("{0}:{1}", item.Key, item.Value);
    }
