    public static IEnumerable<Type> GetTypesThatInheritFrom<T>(this Assembly asm)
    {
        var types = from t in asm.GetTypes()
                    where typeof(T).IsAssignableFrom(t)
                    select t;
        return types;
    }
