    /// <summary>
    /// Test if a type implements IList of T, and if so, determine T.
    /// </summary>
    public static bool TryListOfWhat(Type type, out Type innerType)
    {
        Contract.Requires(type != null);
        var interfaceTest = new Func<Type, Type>(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IList<>) ? i.GetGenericArguments().Single() : null);
        innerType = interfaceTest(type);
        if (innerType != null)
        {
            return true;
        }
        foreach (var i in type.GetInterfaces())
        {
            innerType = interfaceTest(i);
            if (innerType != null)
            {
                return true;
            }
        }
        return false;
    }
