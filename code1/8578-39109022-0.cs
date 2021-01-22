        public static Dictionary<K,V> CloneDictionary<K,V>(Dictionary<K,V> dict) where K : ICloneable where V : ICloneable
        {
            Dictionary<K, V> newDict = null;
            if (dict != null)
            {
                // If the key and value are value types, just use copy constructor.
                if (((typeof(K).IsValueType || typeof(K) == typeof(string)) &&
                     (typeof(V).IsValueType) || typeof(V) == typeof(string)))
                {
                    newDict = new Dictionary<K, V>(dict);
                }
                else // prepare to clone key or value or both
                {
                    newDict = new Dictionary<K, V>();
                    foreach (KeyValuePair<K, V> kvp in dict)
                    {
                        K key;
                        if (typeof(K).IsValueType || typeof(K) == typeof(string))
                        {
                            key = kvp.Key;
                        }
                        else
                        {
                            key = (K)kvp.Key.Clone();
                        }
                        V value;
                        if (typeof(V).IsValueType || typeof(V) == typeof(string))
                        {
                            value = kvp.Value;
                        }
                        else
                        {
                            value = (V)kvp.Value.Clone();
                        }
                        newDict[key] = value;
                    }
                }
            }
            return newDict;
        }
