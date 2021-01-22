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
            if (returnDefaultOnException || underlyingTypeOfNullable != null)
                return default(T);
            throw new InvalidCastException("Object can't be cast to " + type.Name, exception);
        }
    }
    public static T To<T>(this Object @object) { return @object.To<T>(returnDefaultOnException: false); }
    public static T ToOrDefault<T>(this Object @object) { return @object.To<T>(returnDefaultOnException: true); }
