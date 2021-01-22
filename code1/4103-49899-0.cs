      public class KeyValueToObjectFactory
      { 
         private Dictionary<String, Type> _kvTypes = new Dictionary<String, Type>();
    
        public KeyValueToObjectFactory()
        {
            // Preload the Types into a dictionary so we can look them up later
            // Obviously, you want to reuse the factory to minimize overhead, so don't
            // do something stupid like instantiate a new factory in a loop.
            foreach (Type type in typeof(KeyValueToObjectFactory).Assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(KVObjectBase)))
                {
                    _kvTypes[type.Name.ToLower()] = type;
                }
            }
        }
    
        public KVObjectBase CreateObjectFromKV(KeyValuePair<String,String> kv)
        {
            if (kv != null)
            {
                string kvName = kv.Key;
               
                // If the Type information is in our Dictionary, instantiate a new instance of that class.
                Type kvType;
                if (_kvTypes.TryGetValue(kvName, out kvType))
                {
                    return (KVObjectBase)Activator.CreateInstance(kvType, kv.Value);
                }
                else
                {
                    throw new ArgumentException("Unrecognized KV Pair");
                }
            }
            else
            {
                return null;
            }
        }
    }
