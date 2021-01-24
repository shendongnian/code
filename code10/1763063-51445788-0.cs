    [Serializable]
    public class WebServiceDictionary : ISerializable
    {
        public Dictionary<string, string> Entries { get; }
    
        public WebServiceDictionary()
        {
            Entries = new Dictionary<string, string>();
        }
        public WebServiceDictionary(SerializationInfo info, StreamingContext context)
        {
            Entries = new Dictionary<string, string>();
            foreach (var entry in info)
                Entries.Add(entry.Name, entry.Value.ToString());
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (var entry in Entries)
                info.AddValue(entry.Key, entry.Value);
        }
    }
