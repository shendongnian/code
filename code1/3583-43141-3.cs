    public static T[] LoadObjectListAll()
    {
        var session = GetNewSession())
        var criteria = session.CreateCriteria(typeof(T));
        var results = criteria.List<T>();
        return results.ToArray();        
    }
