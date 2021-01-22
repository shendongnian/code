    public static void Print<T>(T obj)
    {
        Type type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();
        foreach(PropertyInfo pi in properties)
        {
            Console.WriteLine(pi.Name + ": " + pi.GetValue(obj, null));
        }
    }
