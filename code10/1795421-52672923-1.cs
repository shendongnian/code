    public Dictionary<int, int> TempRange
    {
        get 
        {
            return HighTemps.ToDictionary(k => k.Key, v => v.Value - LowTemps[v.Key]);
        }
    }
