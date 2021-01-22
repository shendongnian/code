    static readonly MethodInfo CastMethod = typeof(Enumerable).GetMethod("Cast");
    static readonly MethodInfo ToListMethod = typeof(Enumerable).GetMethod("ToList");
    ...
    var castItems = CastMethod.MakeGenericMethod(new Type[] { targetType })
                              .Invoke(null, new object[] { items });
    var list = ToListMethod.MakeGenericMethod(new Type[] { targetType })
                              .Invoke(null, new object[] { castItems });
