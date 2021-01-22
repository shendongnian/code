    public class SerializableDictionary<string, TValue>
        : Dictionary<string, TValue>, IXmlSerializable
    {
        public SerializableDictionary()
            : base(StringComparer.InvariantCultureIgnoreCase)
        {
        }
        // ...
    }
