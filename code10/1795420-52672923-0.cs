    public Dictionary<int, int> TempRange2
    {
        get 
        {
            return HighTemps.ToDictionary(k => k.Key, v => v.Value - LowTemps[v.Key]);
        }
    }
