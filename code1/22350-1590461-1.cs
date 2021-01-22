    public static T GetValue<T>(this NameValueCollection collection, string key)
        {
            if (collection == null)
            {
                return default(T);
            }
            var value = collection[key];
            if (value == null)
            {
               return default(T);
            }
            var type = typeof(T);
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = Nullable.GetUnderlyingType(type);
            }
            var converter = TypeDescriptor.GetConverter(type);
            if (!converter.CanConvertTo(value.GetType()))
            {
                return default(T);
            }
            return (T)converter.ConvertTo(value, type);
        }
