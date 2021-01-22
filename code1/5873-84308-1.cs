    public static Dictionary<TKey, TValue> DeepCopy<TKey,TValue>(this Dictionary&lt;TKey, TValue> dictionary)
            {
                Dictionary<TKey, TValue> d2 = new Dictionary<TKey, TValue>();
    
                bool keyIsCloneable = default(TKey) is ICloneable;
                bool valueIsCloneable = default(TValue) is ICloneable;
    
                foreach (KeyValuePair<TKey, TValue> kvp in dictionary)
                {
                    TKey key = default(TKey);
                    TValue value = default(TValue);
                    if (keyIsCloneable)
                    {
                        key = (TKey)((ICloneable)(kvp.Key)).Clone();
                    }
    
                    else
                    {
                        key = kvp.Key;
                    }
    
                    if (valueIsCloneable)
                    {
                        value = (TValue)((ICloneable)(kvp.Value)).Clone();
                    }
    
                    else
                    {
                        value = kvp.Value;
                    }
    
                    d2.Add(key, value);
                }
    
                return d2;
            }
