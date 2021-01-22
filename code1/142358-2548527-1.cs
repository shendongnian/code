    public static bool ImplementsBaseType(IEnumerable objects)
    {
        int found = ( from i in objects.GetType().GetInterfaces()
                     where i.IsGenericType && 
                            i.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                     from arg in i.GetGenericArguments()
                     where arg.BaseType == typeof(MyBaseClass)
                     select i ).Count();
        return (found > 0);
    }
