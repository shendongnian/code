    static void DoSomething<T>()
    {
        List<Type> collections = new List<Type>() { typeof(IEnumerable<>), typeof(IEnumerable) };
    
        foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
        {
            if (propertyInfo.PropertyType != typeof(string) && propertyInfo.PropertyType.GetInterfaces().Any(i => collections.Any(c => i == c)))
            {
                continue;
            }
    
            Console.WriteLine(propertyInfo.Name);
        }
    }
