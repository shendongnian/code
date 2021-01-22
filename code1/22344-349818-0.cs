    public static T GetValue<T>(this NameValueCollection collection, string key)
    {
        if(collection == null)
        {
            throw new ArgumentNullException("collection");
        }
        var value = collection[key];
        if(value == null)
        {
            throw new ArgumentOutOfRangeException("key");
        }
        var converter = TypeDescriptor.GetConverter(value);
        if(!converter.CanConvertTo(typeof(T)))
        {
            throw new ArgumentException(String.Format("Cannot convert '{0}' to {1}", value, typeof(T)));
        }
        return (T) converter.ConvertTo(value, typeof(T));
    }
