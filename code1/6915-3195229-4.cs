    public static List<T> GetEnumValues<T>() where T : new() {
        T valueType = new T();
        return typeof(T).GetFields()
            .Select(fieldInfo => (T)fieldInfo.GetValue(valueType))
            .Distinct()
            .ToList();
    }
    public static List<String> GetEnumNames<T>() {
        return typeof (T).GetFields()
            .Select(info => info.Name)
            .Distinct()
            .ToList();
    }
