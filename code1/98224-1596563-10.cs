    public class NestedMultiDimDictList<K, K2, T>: 
               MultiDimDictList<K, MultiDimDictList<K2, T>>: 
    {
           public void Add(K key, K2 key2, T addObject)
           {
               if(!ContainsKey(key)) Add(key, 
                      new MultiDimDictList<K2, T>());
               if (!base[key].Contains(key2)) 
                   base[key].Add(key2, addObject);
           }    
    }
