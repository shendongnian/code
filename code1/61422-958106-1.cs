    static public IEnumerable<PropertyInfo> PropertyDiff(Type t1, Type t2)
    {
        var d1 = t1.GetProperties().ToDictionary(x => x.Name);
        var d2 = t2.GetProperties().ToDictionary(x => x.Name);
        return DictionaryDiff(d1, d2);
    }
