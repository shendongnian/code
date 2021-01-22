    public static EntityCollection<T> ToEntityCollection<T>(this List<T> list) where T : class
    {
        EntityCollection<T> entityCollection = new EntityCollection<T>();
        list.ForEach(entityCollection.Add);
        return entityCollection;
    }
