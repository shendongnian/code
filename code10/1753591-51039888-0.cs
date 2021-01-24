    var masters = new[]
    {
        new[] { 1 },
        new[] { 2, 3 },
        new[] { 4, 5, 6, 7 },
        new[] { 8 }
    };
    var data = new[] 
    {
        new[] { 1 },
        new[] { 3, 9 },
        new[] { 2 },
    };
    
    // Has masters[i] already been "consumed"?
    var used = new bool[masters.Length];
    // The found indexes in masters. -1 if not found/already used
    var res = new int[data.Length];
    for (int i = 0; i < data.Length; i++)
    {
        // The default condition is "not found"
        res[i] = -1;
        for (int j = 0; j < masters.Length; j++)
        {
            // If masters[j] already used/consumed, then skip it
            if (used[j])
            {
                continue;
            }
            // We are looking for an intersection between masters[j] and data[i]
            if (masters[j].Intersect(data[i]).Any())
            {
                used[j] = true;
                res[i] = j;
                break;
            }
        }
    }
