     public void OnBeforeSerialize()
     {
         keys.Clear();
         values.Clear();
         foreach(KeyValuePair<TKey, TValue> pair in this)
         {
             pair.Value.GuidToString();
             keys.Add(pair.Key);
             values.Add(pair.Value);
         }
     }
