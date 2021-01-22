    public static bool TryDeserialize<T>(XmlReader reader, out T obj) where T : class
    {
        // Return null, if we can't deserialize
        obj = null;
        XmlSerializer deserializer = new XmlSerializer(typeof(T));
        bool result = deserializer.CanDeserialize(reader);
        if (result)
        {
            // Get the object, if it's possible
            obj = deserializer.Deserialize(reader) as T;
        }
        return result;
    }
