    public static List<T> ToList<T>(DataTable dt)
        where T : IFoo, new()
    {
        ...
        foreach ( ... ) {
           var foo = new T();
           foo.Initialize(dataRow);
           list.Add(foo);
        }
        ...
    }
