    public bool Contains(
        List<Dictionary<string, object>> first,
        List<Dictionary<string, object>> second) {
        if(first == null) {
            throw new ArgumentNullException("first");
        }
        if(second == null) {
            throw new ArgumentNullException("second");
        }
        IEqualityComparer<Dictionary<string, object>> comparer = new DictionaryComparer<string, object>();
        return second.All(y => first.Contains(y, comparer));
    }
        
