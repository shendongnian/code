    string className = "System.String";
    Type type = Type.GetType(className);
    var listType = typeof(List<>).MakeGenericType(type);
    // This is a List<type> but it is easier to handle it through
    // its non-generic IEnumerable interface
    var list = (IEnumerable)Activator.CreateInstance(listType);
    // Note that in truth this will return a IQueryable<type>
    IQueryable queryable = Queryable.AsQueryable(list);
