    static void DoSomething<T>()
    {
        List<Type> collections = new List<Type>() 
        { typeof(ICollection<>), typeof(IList<>), typeof(IEnumerable<>), 
            typeof(ICollection), typeof(IList), typeof(IEnumerable) };
    
        foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
        {
            if (propertyInfo.PropertyType != typeof(string) && propertyInfo.PropertyType.GetInterfaces().Any(i => collections.Any(c => i == c)))
            {
                continue;
            }
    
            Console.WriteLine(propertyInfo.Name);
        }
    }
