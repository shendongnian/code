    [DataContract]
    public class RootObject
    {
        Dictionary<string, string> dictionary;
        [DataMember]
        public Dictionary<string, string> Dictionary
        {
            get
            {
                if (dictionary == null)
                    System.Threading.Interlocked.CompareExchange(ref dictionary, new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase), null);
                return dictionary;
            }
            // DO NOT ADD A SET METHOD EVEN IF PRIVATE, it will break data contract serialization.
        }
    }
