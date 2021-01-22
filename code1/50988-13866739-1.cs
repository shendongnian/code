    private static T To<T>(this Object @object, Boolean returnDefaultOnException)
    {
        Type type = typeof(T);
        Type underlyingTypeOfNullable = Nullable.GetUnderlyingType(type);
        try
        {
            return (T) Convert.ChangeType(@object, underlyingTypeOfNullable ?? type);
        }
        catch (Exception exception)
        {
            if (returnDefaultOnException)
                return default(T);
            String typeName = type.Name;
            if (underlyingTypeOfNullable != null)
                typeName += " of " + underlyingTypeOfNullable.Name;
            throw new InvalidCastException("Object can't be cast to " + typeName, exception);
        }
    }
    public static T To<T>(this Object @object) { return @object.To<T>(returnDefaultOnException: false); }
    public static T ToOrDefault<T>(this Object @object) { return @object.To<T>(returnDefaultOnException: true); }
