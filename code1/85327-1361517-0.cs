    public IEnumerable<Type> GetTypes(Assembly assembly) 
    {
        foreach(Type type in assembly.GetTypes()) 
        {
            if (type.GetCustomAttributes(typeof(DefaultNameAttribute), true).Length > 0) 
            {
                yield return type;
            }
        }
    }
