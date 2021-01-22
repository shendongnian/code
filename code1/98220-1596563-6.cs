       public class MultiDimDictList<K, T>: Dictionary<K, List<T>>  
       {
           public void Add(K key, T addObject)
           {
               if(!ContainsKey(key)) Add(key, new List<T>());
               if (!base[key].Contains(addObject)) base[key].Add(addObject);
           }           
       }
       
      // and to use it, in client code
        var myDicList = new MultiDimDictList<string, int> ();
        myDicList.Add("ages", 23);
        myDicList.Add("ages", 32);
        myDicList.Add("ages", 18);
        myDicList.Add("salaries", 80000);
        myDicList.Add("salaries", 110000);
        myDicList.Add("accountIds", 321123);
        myDicList.Add("accountIds", 342653);
  
  
