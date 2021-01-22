    static void DoSomething<T>()
    {
        foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
        {
            if (propertyInfo.PropertyType != typeof(string)
                && propertyInfo.PropertyType.GetInterface(typeof(IEnumerable).Name) != null
                && propertyInfo.PropertyType.GetInterface(typeof(IEnumerable<>).Name) != null)
            {
                continue;
            }
    
            Console.WriteLine(propertyInfo.Name);
        }
    }
