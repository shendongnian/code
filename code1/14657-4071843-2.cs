        private static void AssertThatTypeAndPropertiesAreSerializable(Type type)
        {
            // base case
            if (type.IsValueType || type == typeof(string)) return;
            Assert.IsTrue(type.IsSerializable, type + " must be marked [Serializable]");
            foreach (var propertyInfo in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (propertyInfo.PropertyType.IsGenericType)
                {
                    foreach (var genericArgument in propertyInfo.PropertyType.GetGenericArguments())
                    {
                        if (genericArgument == type) continue; // base case for circularly referenced properties
                        AssertThatTypeAndPropertiesAreSerializable(genericArgument);
                    }
                }
                else if (propertyInfo.GetType() != type) // base case for circularly referenced properties
                    AssertThatTypeAndPropertiesAreSerializable(propertyInfo.PropertyType);
            }
        }
