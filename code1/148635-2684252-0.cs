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
        }
    }
