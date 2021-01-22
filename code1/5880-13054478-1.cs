        private static void NonSerializableTypesOfParentType(Type type, List<string> nonSerializableTypes)
        {
            // base case
            if (type.IsValueType || type == typeof(string)) return;
            if (!IsSerializable(type))
                nonSerializableTypes.Add(type.Name);
            foreach (var propertyInfo in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (propertyInfo.PropertyType.IsGenericType)
                {
                    foreach (var genericArgument in propertyInfo.PropertyType.GetGenericArguments())
                    {
                        if (genericArgument == type) continue; // base case for circularly referenced properties
                        NonSerializableTypesOfParentType(genericArgument, nonSerializableTypes);
                    }
                }
                else if (propertyInfo.GetType() != type) // base case for circularly referenced properties
                    NonSerializableTypesOfParentType(propertyInfo.PropertyType, nonSerializableTypes);
            }
        }
        private static bool IsSerializable(Type type)
        {
            return (Attribute.IsDefined(type, typeof(SerializableAttribute)));
            //return ((type is ISerializable) || (Attribute.IsDefined(type, typeof(SerializableAttribute))));
        }
