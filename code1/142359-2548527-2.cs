    public static bool ImplementsBaseType(IEnumerable objects)
    {
        int found = ( from i in objects.GetType().GetInterfaces()
                     where i.IsGenericType && 
                           i.GetGenericTypeDefinition() == typeof(IEnumerable<>) &&
                           typeof(MyBaseClass).IsAssignableFrom(i.GetGenericArguments()[0])
                     select i ).Count();
        return (found > 0);
    }
