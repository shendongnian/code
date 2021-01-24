    static public object LateCast(this ICollection items, Type itemType)
    {
        var methodDefintionForCast = typeof(System.Linq.Enumerable)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Where(mi => mi.Name == "Cast")
            .Select(mi => mi.GetGenericMethodDefinition())
            .Single(gmd => gmd != null && gmd.GetGenericArguments().Length == 1);
        var method = methodDefintionForCast.MakeGenericMethod(new Type[] { itemType });
        return method.Invoke(null, new[] { items });
    }
