    private object ConvertNullable(object value, Type nullableType)
    {
        Type resultType = typeof(Nullable<>).MakeGenericType(nullableType.GetGenericArguments());
        return Activator.CreateInstance(resultType, Convert.ChangeType(value, nullableType.GetGenericArguments()[0]));
    }
    ...
    Type anonimousType = typeof(Nullable<int>);
    object nullableInt1 = ConvertNullable("5", anonimousType);
    // or evident Type
    Nullable<int> nullableInt2 = (Nullable<int>)ConvertNullable("5", typeof(Nullable<int>));
