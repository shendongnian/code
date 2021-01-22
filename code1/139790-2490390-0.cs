    public static object DefaultValue(Type maybeNullable)
    {
        Type underlying = Nullable.GetUnderlyingType(maybeNullable);
        if (underlying != null)
            return Activator.CreateInstance(underlying);
        return Activator.CreateInstance(maybeNullable);
    }
