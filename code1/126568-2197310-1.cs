    public static int GetEntityID<T>(string name) 
        where T : IAnimal
    {
        T obj = _db.GetTable<T>().SingleOrDefault(t => t.name == name);
        return obj != null ? obj.id : 0;
    }
