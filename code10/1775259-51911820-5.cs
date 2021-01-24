        public class OrdinalIgnoreCaseDictionary<TValue> : Dictionary<string, TValue>
        {
            public OrdinalIgnoreCaseDictionary() : base(StringComparer.OrdinalIgnoreCase) { }
        }
        [DataContract]
        public class RootObject
        {
            [DataMember]
            public OrdinalIgnoreCaseDictionary<string> Dictionary { get; set; }
        }
