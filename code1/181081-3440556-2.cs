    public class SerializableDictionary<TValue>
        : Dictionary<string, TValue>, IXmlSerializable
    {
        public SerializableDictionary()
            : base(StringComparer.InvariantCultureIgnoreCase)
        {
        }
        // ...
    }
