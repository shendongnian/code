    public static IEnumerable<string> GetEnumNames<T>()
    {
        Type enumType = typeof(T);
        var fields = from field in enumType.GetFields()
                     where field.IsLiteral
                     select ((T)field.GetValue(enumType)).ToString();
        return fields;
    }
