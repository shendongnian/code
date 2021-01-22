    public static T GetValue<T>(object[] inputs)
    {
        if (typeof(T).IsArray)
        {
            Type elementType = typeof(T).GetElementType();
            Array array = Array.CreateInstance(elementType, inputs.Length);
            inputs.CopyTo(array, 0);
            T obj = (T)(object)array;
            return obj;
        }
        else
        {
            return (T)inputs[0];
            // will throw on 0-length array, check for length == 0 and return default(T)
            // if do not want exception
        }
    }
