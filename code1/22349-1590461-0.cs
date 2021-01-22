    public static T GetValue<T>(this NameValueCollection collection, string key)
            {
                if (collection == null)
                {
                    throw new ArgumentNullException("collection");
                }
    
                var value = collection[key];
                var type = typeof(T);
    
                if (value == null)
                {
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                        return default(T);
    
                    throw new ArgumentOutOfRangeException("key");
                }
    
                var converter = TypeDescriptor.GetConverter(type);
    
                if (!converter.CanConvertTo(value.GetType()))
                {
                    throw new ArgumentException(String.Format("Cannot convert '{0}' to {1}", value, type));
                }
    
                return (T)converter.ConvertTo(value, type);
            }
