    public string ListType<T>(T value)
    {
        var valueType = value.GetType().GenericTypeArguments[0].FullName;
        return valueType;
    }
