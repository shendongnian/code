    public bool IsList(object value) {
        return value is IList 
            || IsGenericList(value);
    }
    public bool IsGenericList(object value) {
        var type = value.GetType();
        return type.IsGenericType
            && typeof(List<>) == type.GetGenericTypeDefinition();
    }
