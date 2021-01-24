    var type = property.PropertyType;
    object value;
    if (type.IsEnum)
    {
        value = GetValue(type, "ChoiceOne");
    }
    else if (type.IsGenericType &&
        type.GetGenericTypeDefinition() == typeof(Nullable<>) &&
        type.GetGenericArguments()[0].IsEnum)
    {
        value = GetValue(type.GetGenericArguments()[0], "ChoiceOne");
    }
