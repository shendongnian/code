    public static Boolean IsImmutable(this Type type)
    {
        const BindingFlags flags = BindingFlags.Instance |
                                   BindingFlags.NonPublic |
                                   BindingFlags.Public;
        return type.GetFields(flags).All(f => f.IsInitOnly);
    }
    public static Boolean IsImmutable(this Object @object)
    {
        return @object == null || @object.GetType().IsImmutable();
    }
