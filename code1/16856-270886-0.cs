        [Serializable]
        public class SDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializable
        {
            public SDictionary()
                : base()
            {
            }
    
            protected SDictionary(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
    
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                base.GetObjectData(info, context);
            }
    
            public List<ListItem> ToListItems()
            {
                return this.Convert(delegate(TKey key, TValue value)
                {
                    return new ListItem(key.ToString(), value.ToString());
                });
            }
            public List<U> Convert<U>(CombinationFunctionDelegate<U, TKey, TValue> converterFunction)
            {
                List<U> res = new List<U>();
                foreach (TKey key in Keys)
                    res.Add(converterFunction(key, this[key]));
                return res;
            }
    
        }
    
        class Program
        {
    
            static void Main(string[] args)
            {
                SDictionary<string, string> b = new SDictionary<string, string>();
                b.Add("foo", "bar");
    
                System.IO.MemoryStream memStream = new System.IO.MemoryStream();
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                f.Serialize(memStream, b);
                memStream.Position = 0;
    
                b = f.Deserialize(memStream) as SDictionary<string, string>;
            }
    
        }
