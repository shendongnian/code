    public static int GetEntityID<T,K>(string name) 
        where T : IQueryable<T>
        where K : Type
    {
        T obj = _db.GetTable<K>().SingleOrDefault(t => t.name == name);
        return obj != null ? obj.id : 0;
    }
