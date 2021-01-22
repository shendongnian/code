    var adjDictionary = adjList.ToDictionary(av => av.PropName);
    foreach (var p in propList)
    {
        Adjustment a;
        if (adjDictionary.TryGetValue(p.Name, out a))
        {
            p.Total = p.Val + a.AdjVal;
        }
        else
        {
            p.Total = p.Val;
        }
    }
