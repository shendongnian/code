    public Dictionary<DateTime, int> ShrinkDictionary(
        Dictionary<DateTime, int> dict, DateTime min, DateTime max) {
        return dict.Where(kvp => InRange(kvp.Key, min, max))
                   .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
