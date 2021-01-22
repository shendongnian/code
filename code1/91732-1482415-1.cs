    var t = typeof(DateTime?).GetUnderlyingType();    // returns System.DateTime
    // ...
    public static Type GetUnderlyingType(this Type source)
    {
        if (source.IsGenericType
            && (source.GetGenericTypeDefinition() == typeof(Nullable<>)))
        {
            // source is a Nullable type so return its underlying type
            return Nullable.GetUnderlyingType(source);
        }
        // source isn't a Nullable type so just return the original type
        return source;
    }
