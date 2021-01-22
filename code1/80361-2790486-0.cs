    public static object MakeDefault(this Type type)
    {
        var makeDefault = typeof(ExtReflection).GetMethod("MakeDefaultGeneric");
        var typed = makeDefault.MakeGenericMethod(type);
        return typed.Invoke(null, new object[] { });
    }
    public static T MakeDefaultGeneric<T>()
    {
        return default(T);
    }
