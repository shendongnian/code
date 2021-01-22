    public static T GetEnumeratedType<T>(this IEnumerable<T> _)
    {
        return default(T);
    }
    
    //and now 
    
    var list = new Dictionary<string, int>();
    var stronglyTypedVar = list.GetEnumeratedType();
