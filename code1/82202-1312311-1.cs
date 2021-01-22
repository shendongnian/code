    static Type GetListType(Type type) {
        foreach (Type intType in type.GetInterfaces()) {
            if (intType.IsGenericType
                && intType.GetGenericTypeDefinition() == typeof(IList<>)) {
                return intType.GetGenericArguments()[0];
            }
        }
        return null;
    }
