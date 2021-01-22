    [AttributeUsage(AttributeTargets.Class)]
    class ByteCountAttribute : Attribute
    {
        public int Value { get; private set; }
        public ByteCountAttribute(int count)
        {
            Value = count;
        }
    }
    
    [ByteCount(5)]
    class DataFormat1 : BaseDataFormat{}  // data stored in 3 bytes
    [ByteCount(6)]
    class DataFormat2 : BaseDataFormat{} /// data stored in 4 bytes
    
    static Dictionary<Type, int> s_typeCache = new Dictionary<Type,int>();
    public static int GetByteCount<T>() where T : BaseDataFormat
    {
        int result;
        var type = typeof(T);
        if (!s_typeCache.TryGetValue(type, out result))
        {
            var atts = type.GetCustomAttributes(typeof(ByteCountAttribute), false);
            result = ((ByteCountAttribute)atts[0]).Value;
            s_typeCache.Add(type, result);
        }
        return result;
    }
