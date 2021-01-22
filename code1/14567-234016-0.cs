    public Dictionary<Type, object> GenerateLists(List<Type> types)
    {
        Dictionary<Type, object> lists = new Dictionary<Type, object>();
        foreach (Type type in types)
        {
            Type genericList = typeof(List<>).MakeGenericType(type);
            lists.Add(type, Activator.CreateInstance(genericList));
        }
        return lists;
    }
