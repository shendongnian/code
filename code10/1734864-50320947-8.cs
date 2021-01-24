        static Type GetValueType(Type objectType)
        {
            return objectType
                .BaseTypesAndSelf()
				.Skip(1) // Do not apply the converter to ValueObject<T> when not subclassed
                .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ValueObject<>))
                .Select(t => t.GetGenericArguments()[0])
                .FirstOrDefault();
        }
