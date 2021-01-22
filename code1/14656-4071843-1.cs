    private static void AssertThatTypeAndPropertiesAreSerializable(Type type)
    {
        if (type.IsValueType || type == typeof(string)) return;
        Assert.IsTrue(type.IsSerializable, type + " must be marked [Serializable]");
        foreach (var propertyInfo in type.GetProperties())
        {
            AssertThatTypeAndPropertiesAreSerializable(propertyInfo.PropertyType.IsGenericType
                                                           ? propertyInfo.PropertyType.GetGenericArguments()[0]
                                                           : propertyInfo.PropertyType);
        }
    }
