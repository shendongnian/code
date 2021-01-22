    public static Type[] GetDirectInterfaces(Type type)
    {
        if (type.BaseType == null)
            return type.GetInterfaces();
        Type[] BaseInterfaces = type.BaseType.GetInterfaces();
        Type[] ThisInferfaces = type.GetInterfaces();
        return ThisInferfaces.Except(BaseInterfaces).ToArray();
    }
