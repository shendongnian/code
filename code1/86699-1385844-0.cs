    private static readonlyDictionary<Type, Func<object, byte[]>> Converters = 
        new Dictionary<Type, Func<object, byte[]>>()
    {
        { typeof(string), o => Encoding.UTF8.GetBytes((string) o) },
        { typeof(bool), o => BitConverter.GetBytes((bool) o) },
        { typeof(char), o => BitConverter.GetBytes((char) o) },
        ...
    };
    public static void ToBytes(object[] data, byte[] buffer)
    {
        int offset = 0;
    
        foreach (object obj in data)
        {
            if (obj == null)
            {
                // Or do whatever you want
                throw new ArgumentException("Unable to convert null values");
            }
            Func<object, byte[]> converter;
            if (!Converters.TryGetValue(obj.GetType(), out converter))
            {
                throw new ArgumentException("No converter for " + obj.GetType());
            }
    
            byte[] obytes = converter(obj);
            Buffer.BlockCopy(obytes, 0, buffer, offset, obytes.Length);
            offset += obytes.Length;
        }
    }
