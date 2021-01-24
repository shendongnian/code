    var result = new List<string>();
    foreach (var i in Enumerable.Range(0, 101))
    {
        foreach (var j in Enumerable.Range(0, 101))
        {
            result.Add($"A{i:00}B{j:00}");
        }
    }
