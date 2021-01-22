    if (item.PropertyType.IsGenericType) {
        if (item.PropertyType.GetGenericType() == typeof(Nullable<>)) {
            var valueType = item.PropertyType.GetGenericArguments()[0];
        }
    }
