    public static List<T> getEnumValues<T>() where T : new() {
        T valueType = new T();
        return typeof(T).GetFields()
            .Select(fieldInfo => (T)fieldInfo.GetValue(valueType))
            .Distinct()
            .ToList();
    }
    public static List<String> getEnumNames<T>() {
        return typeof (T).GetFields()
            .Select(info => info.Name)
            .Distinct()
            .ToList();
    }
