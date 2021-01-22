       public class MultiDimDictList<K, T>: Dictionary<K, List<T>>  { }
       
      // to use it, in client code
       var myDicList = new MultiDimDictList<string, int> ();
       myDicList.Add("ages", new List<T>()); 
       myDicList["ages"].Add(23);
       myDicList["ages"].Add(32);
       myDicList["ages"].Add(18);
       myDicList.Add("salaries", new List<T>());
       myDicList["salaries"].Add(80000);
       myDicList["salaries"].Add(100000);
 
       myDicList.Add("accountIds", new List<T>()); 
       myDicList["accountIds"].Add(321123);
       myDicList["accountIds"].Add(342653);
 
