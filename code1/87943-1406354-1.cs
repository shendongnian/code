    private static List<T> CastAndList(IEnumerable items)
    {
        return items.Cast<T>().ToList();
    }
    private static readonly MethodInfo CastAndListMethod = 
        typeof(YourType).GetMethod("CastAndList", 
                                   BindingFlags.Static | BindingFlags.NonPublic);
    public static object CastAndList(object items, Type targetType)
    {
        return CastAndListMethod.MakeGenericMethod(new[] { targetType })
                                .Invoke(null, new[] { items });
    }
