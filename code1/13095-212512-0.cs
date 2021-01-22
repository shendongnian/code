    public static T[] CreateProperties<T>(IProperty[] properties)
        where T : class, new()
    {
        //Empty so return null
        if (properties==null || properties.Length == 0)
            return null;
        //Check the type is allowed
        CheckPropertyTypes("CreateProperties(Type,IProperty[])",typeof(T));
        //Convert the array of intermediary IProperty objects into
        // the passed service type e.g. Service1.Property
        T[] result = new T[properties.Length];
        for (int i = 0; i < properties.Length; i++)
        {
            T[i] = new T();
            ServiceUtils.CopyProperties(properties[i], t[i]);
        }
        return result;
    }
