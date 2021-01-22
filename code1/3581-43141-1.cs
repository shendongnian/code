    public static T[] LoadObjectListAll()
    {
        using (var session = GetNewSession())
        {
           var criteria = session.CreateCriteria(typeof(T));
           var results = criteria.List<T>();
           return results.ToArray();
        }
    }
